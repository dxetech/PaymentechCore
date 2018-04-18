using System;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using RestSharp;

namespace PaymentechCore.Services
{
    public class PaymentechClientOptions
    {
        public string InterfaceVersion { get; set; }
        public Credentials Credentials { get; set; }
        public bool Production { get; set; }
    }

    public class PaymentechClient
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

        public RestRequest _buildRequest(object xmlBody, string traceNumber = null)
        {
            if (string.IsNullOrEmpty(traceNumber))
            {
                traceNumber = Guid.NewGuid().ToString();
            }
            var previousRequest = _cache.GetValue(traceNumber);
            if (!string.IsNullOrEmpty(previousRequest))
            {
                return null;
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

            return request;
        }

        public Models.ResponseModels.accountUpdaterRespType UpdateAccount(Models.RequestModels.accountUpdaterType accountUpdate, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = accountUpdate };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.accountUpdaterRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.endOfDayRespType EndOfDay(Models.RequestModels.endOfDayType endOfDay, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = endOfDay };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.endOfDayRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.flexCacheRespType FlexCache(Models.RequestModels.flexCacheType flexCache, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = flexCache };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.flexCacheRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.inquiryRespType FlexCache(Models.RequestModels.inquiryType inquiryResp, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = inquiryResp };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.inquiryRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.markForCaptureRespType FlexCache(Models.RequestModels.markForCaptureType markForCapture, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = markForCapture };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.markForCaptureRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.newOrderRespType FlexCache(Models.RequestModels.newOrderType newOrder, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = newOrder };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.newOrderRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.profileRespType Profile(Models.RequestModels.profileType profile, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = profile };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.profileRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.reversalRespType Reversal(Models.RequestModels.reversalType reversal, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = reversal };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.reversalRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.safetechFraudAnalysisRespType Reversal(Models.RequestModels.safetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null)
        {
            var xmlBody = new Models.RequestModels.Request { Item = safetechFraudAnalysis };
            var request = _buildRequest(xmlBody, traceNumber);
            if (request == null)
            {
                return null;
            }
            var response = _restClient.Execute<Models.ResponseModels.safetechFraudAnalysisRespType>(request);
            return response.Data;
        }
    }
}