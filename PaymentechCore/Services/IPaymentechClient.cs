using System;
using System.Threading.Tasks;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;

namespace PaymentechCore.Services
{
    public interface IPaymentechClient
    {
        Credentials Credentials { get; set; }
        string InterfaceVersion { get; set; }
        Endpoint Endpoint { get; set; }
        IPaymentechCache GetCache();
        string NewTraceNumber();
        ClientResponse UpdateAccount(AccountUpdaterType accountUpdate, string traceNumber = null);
        Task<ClientResponse> UpdateAccountAsync(AccountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse EndOfDay(EndOfDayType endOfDay, string traceNumber = null);
        Task<ClientResponse> EndOfDayAsync(EndOfDayType endOfDay, string traceNumber = null);
        ClientResponse FlexCache(FlexCacheType flexCache, string traceNumber = null);
        Task<ClientResponse> FlexCacheAsync(FlexCacheType flexCache, string traceNumber = null);
        ClientResponse Inquiry(InquiryType inquiry, string traceNumber = null);
        Task<ClientResponse> InquiryAsync(InquiryType inquiry, string traceNumber = null);
        ClientResponse MarkForCapture(MarkForCaptureType markForCapture, string traceNumber = null);
        Task<ClientResponse> MarkForCaptureAsync(MarkForCaptureType markForCapture, string traceNumber = null);
        ClientResponse NewOrder(NewOrderType newOrder, string traceNumber = null);
        Task<ClientResponse> NewOrderAsync(NewOrderType newOrder, string traceNumber = null);
        ClientResponse Profile(ProfileType profile, string traceNumber = null);
        Task<ClientResponse> ProfileAsync(ProfileType profile, string traceNumber = null);
        ClientResponse Reversal(ReversalType reversal, string traceNumber = null);
        Task<ClientResponse> ReversalAsync(ReversalType reversal, string traceNumber = null);
        ClientResponse SafetechFraudAnalysis(SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
        Task<ClientResponse> SafetechFraudAnalysisAsync(SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}