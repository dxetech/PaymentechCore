using System;
using PaymentechCore.Models.RequestModels;

namespace PaymentechCore.Services
{
    public interface IPaymentechClient
    {
        ClientResponse<Models.ResponseModels.accountUpdaterRespType> UpdateAccount(Models.RequestModels.accountUpdaterType accountUpdate, string traceNumber = null);
        ClientResponse<Models.ResponseModels.endOfDayRespType> EndOfDay(Models.RequestModels.endOfDayType endOfDay, string traceNumber = null);
        ClientResponse<Models.ResponseModels.flexCacheRespType> FlexCache(Models.RequestModels.flexCacheType flexCache, string traceNumber = null);
        ClientResponse<Models.ResponseModels.inquiryRespType> FlexCache(Models.RequestModels.inquiryType inquiryResp, string traceNumber = null);
        ClientResponse<Models.ResponseModels.markForCaptureRespType> FlexCache(Models.RequestModels.markForCaptureType markForCapture, string traceNumber = null);
        ClientResponse<Models.ResponseModels.newOrderRespType> FlexCache(Models.RequestModels.newOrderType newOrder, string traceNumber = null);
        ClientResponse<Models.ResponseModels.profileRespType> Profile(Models.RequestModels.profileType profile, string traceNumber = null);
        ClientResponse<Models.ResponseModels.reversalRespType> Reversal(Models.RequestModels.reversalType reversal, string traceNumber = null);
        ClientResponse<Models.ResponseModels.safetechFraudAnalysisRespType> SafetechFraudAnalysis(Models.RequestModels.safetechFraudAnalysisType safetechFraudAnalysis, string traceNumber = null);
    }
}