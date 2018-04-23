using System;
using PaymentechCore.Models;
using PaymentechCore.Models.ResponseModels;

namespace PaymentechCore.Services
{
    public interface IPaymentechClient
    {
        Credentials Credentials();
        string InterfaceVersion();
        ClientResponse UpdateAccount(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse EndOfDay(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null);
        ClientResponse FlexCache(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null);
        ClientResponse Inquiry(Models.RequestModels.InquiryType inquiry, string traceNumber = null);
        ClientResponse MarkForCapture(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null);
        ClientResponse NewOrder(Models.RequestModels.NewOrderType newOrder, string traceNumber = null);
        ClientResponse Profile(Models.RequestModels.ProfileType profile, string traceNumber = null);
        ClientResponse Reversal(Models.RequestModels.ReversalType reversal, string traceNumber = null);
        ClientResponse SafetechFraudAnalysis(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}