using System;
using System.Threading.Tasks;
using PaymentechCore.Models;
using PaymentechCore.Models.ResponseModels;

namespace PaymentechCore.Services
{
    public interface IPaymentechClient
    {
        Credentials Credentials();
        string InterfaceVersion();
        IPaymentechCache GetCache();
        string NewTraceNumber();
        ClientResponse UpdateAccount(Models.RequestModels.accountUpdaterType accountUpdate, string traceNumber = null);
        Task<ClientResponse> UpdateAccountAsync(Models.RequestModels.accountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse EndOfDay(Models.RequestModels.endOfDayType endOfDay, string traceNumber = null);
        Task<ClientResponse> EndOfDayAsync(Models.RequestModels.endOfDayType endOfDay, string traceNumber = null);
        ClientResponse FlexCache(Models.RequestModels.flexCacheType flexCache, string traceNumber = null);
        Task<ClientResponse> FlexCacheAsync(Models.RequestModels.flexCacheType flexCache, string traceNumber = null);
        ClientResponse Inquiry(Models.RequestModels.inquiryType inquiry, string traceNumber = null);
        Task<ClientResponse> InquiryAsync(Models.RequestModels.inquiryType inquiry, string traceNumber = null);
        ClientResponse MarkForCapture(Models.RequestModels.markForCaptureType markForCapture, string traceNumber = null);
        Task<ClientResponse> MarkForCaptureAsync(Models.RequestModels.markForCaptureType markForCapture, string traceNumber = null);
        ClientResponse NewOrder(Models.RequestModels.newOrderType newOrder, string traceNumber = null);
        Task<ClientResponse> NewOrderAsync(Models.RequestModels.newOrderType newOrder, string traceNumber = null);
        ClientResponse Profile(Models.RequestModels.profileType profile, string traceNumber = null);
        Task<ClientResponse> ProfileAsync(Models.RequestModels.profileType profile, string traceNumber = null);
        ClientResponse Reversal(Models.RequestModels.reversalType reversal, string traceNumber = null);
        Task<ClientResponse> ReversalAsync(Models.RequestModels.reversalType reversal, string traceNumber = null);
        ClientResponse SafetechFraudAnalysis(Models.RequestModels.safetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
        Task<ClientResponse> SafetechFraudAnalysisAsync(Models.RequestModels.safetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}