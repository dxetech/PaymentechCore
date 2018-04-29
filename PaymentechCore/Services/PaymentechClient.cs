using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace PaymentechCore.Services
{
    public class PaymentechClientOptions
    {
        public string InterfaceVersion { get; set; }
        public Credentials Credentials { get; set; }
        public bool Production { get; set; }
    }

    public class PaymentechClient : IPaymentechClient
    {
        private readonly PaymentechClientOptions _options;
        private readonly Endpoint _endpoint;
        private readonly IPaymentechCache _cache;

        public PaymentechClient(IOptions<PaymentechClientOptions> optionsAccessor,
            IPaymentechCache cache)
        {
            _options = optionsAccessor.Value;
            _endpoint = new Endpoint(_options.Credentials, _options.Production);
            _cache = cache;
        }

        private ClientResponse _sendRequest(string url, Request request, string traceNumber = null)
        {
            return _sendRequestAsync(url, request, traceNumber).GetAwaiter().GetResult();
        }

        private ClientResponse _contentToClientResponse(string content, string traceNumber, bool previousRequest = false)
        {
            var responseSerializer = new XmlSerializer(typeof(Response));
            using (var reader = new StringReader(content))
            {
                Response response = (Response)responseSerializer.Deserialize(reader);
                return new ClientResponse
                {
                    Response = response,
                    TraceNumber = traceNumber,
                    PreviousRequest = previousRequest,
                };
            }
        }

        private async Task<ClientResponse> _sendRequestAsync(string url, Request request, string traceNumber = null)
        {
            if (_cache != null && !string.IsNullOrEmpty(traceNumber))
            {
                var previousResponse = _cache.GetValue(traceNumber);
                if (!string.IsNullOrEmpty(previousResponse))
                {
                    return _contentToClientResponse(previousResponse, traceNumber, true);
                }
            }
            var headers = new Headers(traceNumber, _options.InterfaceVersion, _options.Credentials.MerchantId);

            if (string.IsNullOrEmpty(headers.TraceNumber))
            {
                var newTrace = Guid.NewGuid().GetHashCode();
                if (newTrace < 0)
                {
                    newTrace = newTrace * -1;
                }
                headers.TraceNumber = newTrace.ToString();
            }

            var contentType = headers.ContentType();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("MIME-Version", headers.MIME_Version);
            client.DefaultRequestHeaders.Add("Content-transfer-encoding", headers.ContentTransferEncoding);
            client.DefaultRequestHeaders.Add("Request-number", headers.RequestNumber);
            client.DefaultRequestHeaders.Add("Document-type", headers.DocumentType);
            client.DefaultRequestHeaders.Add("Trace-number", headers.TraceNumber);
            client.DefaultRequestHeaders.Add("Interface-version", headers.InterfaceVersion);
            client.DefaultRequestHeaders.Add("MerchantID", headers.MerchantID);

            string body;
            var requestSerializer = new XmlSerializer(typeof(Request));
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                requestSerializer.Serialize(writer, request, ns);

                stream.Position = 0;
                using (var reader = new StreamReader(stream))
                {
                    body = reader.ReadToEnd();
                }
            }

            var httpRequest = new HttpRequestMessage(HttpMethod.Post, "");
            httpRequest.Content = new StringContent(body);
            httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            var httpResponse = await client.SendAsync(httpRequest);
            var httpResponseContent = await httpResponse.Content.ReadAsStringAsync();

            if (httpResponse.IsSuccessStatusCode)
            {
                var clientResponse = _contentToClientResponse(httpResponseContent, traceNumber);

                var itemType = ResponseTypes.Types[clientResponse.Response.Item.GetType()];

                string procStatus = null;
                switch (itemType)
                {
                    case (int)ResponeTypeIds.AccountUpdaterResp:
                        var accountUpdater = (accountUpdaterRespType)clientResponse.Response.Item;
                        procStatus = accountUpdater.ProfileProcStatus;
                        break;
                    case (int)ResponeTypeIds.EndOfDayResp:
                        var endOfDay = (endOfDayRespType)clientResponse.Response.Item;
                        procStatus = endOfDay.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.FlexCacheResp:
                        var flexCache = (flexCacheRespType)clientResponse.Response.Item;
                        procStatus = flexCache.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.InquiryResp:
                        var inquiry = (inquiryRespType)clientResponse.Response.Item;
                        procStatus = inquiry.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.MarkForCaptureResp:
                        var markForCapture = (markForCaptureRespType)clientResponse.Response.Item;
                        procStatus = markForCapture.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.NewOrderResp:
                        var newOrder = (newOrderRespType)clientResponse.Response.Item;
                        procStatus = newOrder.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.ProfileResp:
                        var profile = (profileRespType)clientResponse.Response.Item;
                        procStatus = profile.ProfileProcStatus;
                        break;
                    case (int)ResponeTypeIds.QuickResp:
                        var quick = (quickRespType)clientResponse.Response.Item;
                        procStatus = quick.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.QuickResponse:
                        var quick_old = (quickRespType_old)clientResponse.Response.Item;
                        procStatus = quick_old.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.ReversalResp:
                        var reversal = (reversalRespType)clientResponse.Response.Item;
                        procStatus = reversal.ProcStatus;
                        break;
                    case (int)ResponeTypeIds.SafetechFraudAnalysisResp:
                        var safetechFraudAnalysis = (safetechFraudAnalysisRespType)clientResponse.Response.Item;
                        procStatus = safetechFraudAnalysis.ProcStatus;
                        break;
                    default:
                        break;
                }

                if (procStatus?.Trim() != "0" && procStatus?.Trim() != "00")
                {
                    throw new Exception($"Request was unsuccesful - response was {httpResponseContent}");
                }
                if (!string.IsNullOrEmpty(traceNumber))
                {
                    _cache.SetValue(traceNumber, httpResponseContent);
                }

                return clientResponse;
            }
            else
            {
                throw new Exception($"Unsuccesful communication with Chase with response {httpResponseContent}");
            }
        }

        public Credentials Credentials()
        {
            return _options?.Credentials;
        }

        public string InterfaceVersion()
        {
            return _options?.InterfaceVersion;
        }

        public ClientResponse UpdateAccount(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = accountUpdate };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse EndOfDay(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = endOfDay };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse FlexCache(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = flexCache };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse Inquiry(Models.RequestModels.InquiryType inquiry, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = inquiry };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse MarkForCapture(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = markForCapture };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse NewOrder(Models.RequestModels.NewOrderType newOrder, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = newOrder };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse Profile(Models.RequestModels.ProfileType profile, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = profile };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse Reversal(Models.RequestModels.ReversalType reversal, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = reversal };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }

        public ClientResponse SafetechFraudAnalysis(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = safetechFraudAnalysis };
            return _sendRequest(_endpoint.Url(), xmlBody, traceNumber);
        }
    }
}