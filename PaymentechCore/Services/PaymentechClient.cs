using System;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using RestSharp;

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
        private readonly RestClient _restClient;
        private readonly IPaymentechCache _cache;

        public PaymentechClient(
            IOptions<PaymentechClientOptions> optionsAccessor,
            IPaymentechCache cache)
        {
            _options = optionsAccessor.Value;
            _endpoint = new Endpoint(_options.Credentials, _options.Production);
            _restClient = new RestClient(_endpoint.Url());
            _cache = cache;
        }

        private ClientRequest _buildRequest(object xmlBody, string traceNumber = null)
        {
            if (string.IsNullOrEmpty(traceNumber))
            {
                traceNumber = Guid.NewGuid().ToString();
            }
            if (_cache != null)
            {
                var previousRequest = _cache.GetValue(traceNumber);
                if (!string.IsNullOrEmpty(previousRequest))
                {
                    return new ClientRequest
                    {
                        TraceNumber = traceNumber,
                        PreviousRequest = true,
                    };
                }
            }
            var request = new RestRequest(Method.POST);
            var headers = new Headers(traceNumber, _options.InterfaceVersion, _options.Credentials.MerchantId);
            var headerDict = headers.ToDictionary();
            foreach (var key in headerDict.Keys)
            {
                var value = headerDict[key];
                request.AddHeader(key, value);
            }

            request.AddXmlBody(xmlBody);

            return new ClientRequest
            {
                Request = request,
                TraceNumber = traceNumber,
            };
        }

        public Credentials Credentials()
        {
            return _options?.Credentials;
        }

        public string InterfaceVersion()
        {
            return _options?.InterfaceVersion;
        }

        public ClientResponse<Models.ResponseModels.accountUpdaterRespType> UpdateAccount(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = accountUpdate };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.accountUpdaterRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.accountUpdaterRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.accountUpdaterRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.endOfDayRespType> EndOfDay(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = endOfDay };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.endOfDayRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.endOfDayRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.endOfDayRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.flexCacheRespType> FlexCache(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = flexCache };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.flexCacheRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.flexCacheRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.flexCacheRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.inquiryRespType> Inquiry(Models.RequestModels.InquiryType inquiry, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = inquiry };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.inquiryRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }

            var response = _restClient.Execute<Models.ResponseModels.inquiryRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.inquiryRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.markForCaptureRespType> MarkForCapture(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = markForCapture };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.markForCaptureRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.markForCaptureRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.markForCaptureRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.newOrderRespType> NewOrder(Models.RequestModels.NewOrderType newOrder, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = newOrder };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.newOrderRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.newOrderRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.newOrderRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.profileRespType> Profile(Models.RequestModels.ProfileType profile, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = profile };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.profileRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.profileRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.profileRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.reversalRespType> Reversal(Models.RequestModels.ReversalType reversal, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = reversal };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.reversalRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.reversalRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.reversalRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }

        public ClientResponse<Models.ResponseModels.safetechFraudAnalysisRespType> SafetechFraudAnalysis(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = safetechFraudAnalysis };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            if (request.PreviousRequest)
            {
                return new ClientResponse<Models.ResponseModels.safetechFraudAnalysisRespType>
                {
                    TraceNumber = request.TraceNumber,
                    PreviousRequest = true,
                };
            }
            var response = _restClient.Execute<Models.ResponseModels.safetechFraudAnalysisRespType>(request.Request);
            return new ClientResponse<Models.ResponseModels.safetechFraudAnalysisRespType>
            {
                Response = response,
                TraceNumber = request.TraceNumber,
            };
        }
    }
}