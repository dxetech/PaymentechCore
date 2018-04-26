using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;
using System.Net.Http.Headers;
using System.Text;

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

        public PaymentechClient(
            IOptions<PaymentechClientOptions> optionsAccessor,
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

        private async Task<ClientResponse> _sendRequestAsync(string url, Request request, string traceNumber = null)
        {
            if (string.IsNullOrEmpty(traceNumber))
            {
                var newTrace = Guid.NewGuid().GetHashCode();
                if (newTrace < 0)
                {
                    newTrace = newTrace * -1;
                }
                traceNumber = newTrace.ToString();
            }
            var now = DateTime.Now;
            if (_cache != null)
            {
                var previousRequest = _cache.GetValue(traceNumber);
                if (!string.IsNullOrEmpty(previousRequest))
                {
                    DateTime date;
                    try
                    {
                        date = DateTime.Parse(previousRequest);
                    }
                    catch
                    {
                        date = DateTime.Now;
                    }
                    var diff = DateTime.Now.Subtract(date);
                    if (diff.Hours < 1)
                    {
                        return new ClientResponse
                        {
                            TraceNumber = traceNumber,
                            PreviousRequest = true,
                        };
                    }
                }
            }
            // var result = url.WithHeaders
            // var restRequest = new RestRequest(Method.POST);
            var headers = new Headers(traceNumber, _options.InterfaceVersion, _options.Credentials.MerchantId);

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
            httpResponse.EnsureSuccessStatusCode();
            var httpResponseContent = await httpResponse.Content.ReadAsStringAsync();

            var responseSerializer = new XmlSerializer(typeof(Response));
            using (var reader = new StringReader(httpResponseContent))
            {
                Response response = (Response)responseSerializer.Deserialize(reader);

                _cache.SetValue(traceNumber, now.ToString());

                return new ClientResponse
                {
                    Response = response,
                    TraceNumber = traceNumber,
                };
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