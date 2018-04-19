using System;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;
using PaymentechCore.Services;

namespace PaymentechCoreTests
{
    public class PaymentechTestClient : IPaymentechClient
    {
        private readonly IPaymentechCache _cache;
        private readonly PaymentechClientOptions _clientOptions;
        private readonly IPaymentechClient _client;

        public PaymentechTestClient()
        {
            _cache = new MemoryCache();
            _clientOptions = new PaymentechClientOptions
            {
                InterfaceVersion = Environment.GetEnvironmentVariable("PAYMENTECH_INTERFACE_VERSION"),
                Credentials = new Credentials
                {
                    MerchantId = Environment.GetEnvironmentVariable("PAYMENTECH_MERCHANT_ID"),
                    Username = Environment.GetEnvironmentVariable("PAYMENTECH_USERNAME"),
                    Password = Environment.GetEnvironmentVariable("PAYMENTECH_PASSWORD"),
                },
                Production = false,
            };
            var optionsAccessor = Options.Create(_clientOptions);
            _client = new PaymentechClient(optionsAccessor, _cache);
        }

        public ClientResponse<endOfDayRespType> EndOfDay(EndOfDayType endOfDay, string traceNumber = null)
        {
            return _client.EndOfDay(endOfDay, traceNumber);
        }

        public ClientResponse<flexCacheRespType> FlexCache(FlexCacheType flexCache, string traceNumber = null)
        {
            return _client.FlexCache(flexCache, traceNumber);
        }

        public ClientResponse<inquiryRespType> Inquiry(InquiryType inquiry, string traceNumber = null)
        {
            return _client.Inquiry(inquiry, traceNumber);
        }

        public ClientResponse<markForCaptureRespType> MarkForCapture(MarkForCaptureType markForCapture, string traceNumber = null)
        {
            return _client.MarkForCapture(markForCapture, traceNumber);
        }

        public ClientResponse<newOrderRespType> NewOrder(NewOrderType newOrder, string traceNumber = null)
        {
            return _client.NewOrder(newOrder, traceNumber);
        }

        public ClientResponse<profileRespType> Profile(ProfileType profile, string traceNumber = null)
        {
            return _client.Profile(profile, traceNumber);
        }

        public ClientResponse<reversalRespType> Reversal(ReversalType reversal, string traceNumber = null)
        {
            return _client.Reversal(reversal, traceNumber);
        }

        public ClientResponse<safetechFraudAnalysisRespType> SafetechFraudAnalysis(SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null)
        {
            return _client.SafetechFraudAnalysis(safetechFraudAnalysis, traceNumber);
        }

        public ClientResponse<accountUpdaterRespType> UpdateAccount(AccountUpdaterType accountUpdate, string traceNumber = null)
        {
            return _client.UpdateAccount(accountUpdate, traceNumber);
        }
    }
}