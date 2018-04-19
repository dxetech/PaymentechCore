using System;
using PaymentechCore.Models.RequestModels;

namespace PaymentechCore.Services
{
    public interface IPaymentechClient
    {
        ClientResponse<Models.ResponseModels.accountUpdaterRespType> UpdateAccount(Models.RequestModels.AccountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse<Models.ResponseModels.endOfDayRespType> EndOfDay(Models.RequestModels.EndOfDayType endOfDay, string traceNumber = null);
        ClientResponse<Models.ResponseModels.flexCacheRespType> FlexCache(Models.RequestModels.FlexCacheType flexCache, string traceNumber = null);
        ClientResponse<Models.ResponseModels.inquiryRespType> Inquiry(Models.RequestModels.InquiryType inquiry, string traceNumber = null);
        ClientResponse<Models.ResponseModels.markForCaptureRespType> MarkForCapture(Models.RequestModels.MarkForCaptureType markForCapture, string traceNumber = null);
        ClientResponse<Models.ResponseModels.newOrderRespType> NewOrder(Models.RequestModels.NewOrderType newOrder, string traceNumber = null);
        ClientResponse<Models.ResponseModels.profileRespType> Profile(Models.RequestModels.ProfileType profile, string traceNumber = null);
        ClientResponse<Models.ResponseModels.reversalRespType> Reversal(Models.RequestModels.ReversalType reversal, string traceNumber = null);
        ClientResponse<Models.ResponseModels.safetechFraudAnalysisRespType> SafetechFraudAnalysis(Models.RequestModels.SafetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}