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
        static long MaxTraceNumber = 9999999999999999;
        private readonly IPaymentechCache _cache;
        private readonly PaymentechClientOptions _clientOptions;
        private readonly IPaymentechClient _client;

        public PaymentechTestClient()
        {
            _cache = new MemoryCache();
            _clientOptions = new PaymentechClientOptions
            {
                // ENTER IN CREDENTIALS HERE
                InterfaceVersion = "",
                Credentials = new Credentials
                {
                    MerchantId = "",
                    Username = "",
                    Password = "",
                },
                Production = false,
            };
            var optionsAccessor = Options.Create(_clientOptions);
            _client = new PaymentechClient(optionsAccessor, _cache);
        }

        public Credentials Credentials()
        {
            return _client.Credentials();
        }

        public string InterfaceVersion()
        {
            return _client.InterfaceVersion();
        }

        public IPaymentechCache GetCache()
        {
            return _cache;
        }

        public string NewTraceNumber()
        {
            var newTrace = Guid.NewGuid().GetHashCode();
            if (newTrace < 0)
            {
                newTrace = newTrace * -1;
            }
            var newTraceStr = newTrace.ToString();
            var maxLength = MaxTraceNumber.ToString().Length;
            if (newTraceStr.Length > maxLength)
            {
                newTraceStr = newTraceStr.Substring(0, maxLength - 1);
            }
            return newTraceStr;
        }

        public ClientResponse EndOfDay(EndOfDayType endOfDay, string traceNumber = null)
        {
            return _client.EndOfDay(endOfDay, traceNumber);
        }

        public ClientResponse FlexCache(FlexCacheType flexCache, string traceNumber = null)
        {
            return _client.FlexCache(flexCache, traceNumber);
        }

        public ClientResponse Inquiry(InquiryType inquiry, string traceNumber = null)
        {
            return _client.Inquiry(inquiry, traceNumber);
        }

        public ClientResponse MarkForCapture(MarkForCaptureType markForCapture, string traceNumber = null)
        {
            return _client.MarkForCapture(markForCapture, traceNumber);
        }

        public ClientResponse NewOrder(NewOrderType newOrder, string traceNumber = null)
        {
            return _client.NewOrder(newOrder, traceNumber);
        }

        public ClientResponse Profile(ProfileType profile, string traceNumber = null)
        {
            return _client.Profile(profile, traceNumber);
        }

        public ClientResponse Reversal(ReversalType reversal, string traceNumber = null)
        {
            return _client.Reversal(reversal, traceNumber);
        }

        public ClientResponse SafetechFraudAnalysis(SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null)
        {
            return _client.SafetechFraudAnalysis(safetechFraudAnalysis, traceNumber);
        }

        public ClientResponse UpdateAccount(AccountUpdaterType accountUpdate, string traceNumber = null)
        {
            return _client.UpdateAccount(accountUpdate, traceNumber);
        }
    }
}