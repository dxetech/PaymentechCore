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
        ClientResponse UpdateAccount(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null);
        Task<ClientResponse> UpdateAccountAsync(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse EndOfDay(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null);
        Task<ClientResponse> EndOfDayAsync(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null);
        ClientResponse FlexCache(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null);
        Task<ClientResponse> FlexCacheAsync(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null);
        ClientResponse Inquiry(Models.RequestModels.InquiryType inquiry, string traceNumber = null);
        Task<ClientResponse> InquiryAsync(Models.RequestModels.InquiryType inquiry, string traceNumber = null);
        ClientResponse MarkForCapture(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null);
        Task<ClientResponse> MarkForCaptureAsync(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null);
        ClientResponse NewOrder(Models.RequestModels.NewOrderType newOrder, string traceNumber = null);
        Task<ClientResponse> NewOrderAsync(Models.RequestModels.NewOrderType newOrder, string traceNumber = null);
        ClientResponse Profile(Models.RequestModels.ProfileType profile, string traceNumber = null);
        Task<ClientResponse> ProfileAsync(Models.RequestModels.ProfileType profile, string traceNumber = null);
        ClientResponse Reversal(Models.RequestModels.ReversalType reversal, string traceNumber = null);
        Task<ClientResponse> ReversalAsync(Models.RequestModels.ReversalType reversal, string traceNumber = null);
        ClientResponse SafetechFraudAnalysis(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
        Task<ClientResponse> SafetechFraudAnalysisAsync(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}