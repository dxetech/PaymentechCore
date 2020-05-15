using PaymentechCore.Models.ResponseModels.BaseModels;
using System;
using System.Collections.Generic;

namespace PaymentechCore.Models.ResponseModels
{
    public enum ResponeTypeIds
    {
        AccountUpdaterResp,
        EndOfDayResp,
        FlexCacheResp,
        InquiryResp,
        MarkForCaptureResp,
        NewOrderResp,
        ProfileResp,
        QuickResp,
        QuickResponse,
        ReversalResp,
        SafetechFraudAnalysisResp,
    }

    public static class ResponseTypes
    {
        public static Dictionary<Type, int> Types = new Dictionary<Type, int>
        {
            { typeof(accountUpdaterRespType), (int)ResponeTypeIds.AccountUpdaterResp },
            { typeof(endOfDayRespType), (int)ResponeTypeIds.EndOfDayResp },
            { typeof(flexCacheRespType), (int)ResponeTypeIds.FlexCacheResp },
            { typeof(inquiryRespType), (int)ResponeTypeIds.InquiryResp },
            { typeof(markForCaptureRespType), (int)ResponeTypeIds.MarkForCaptureResp },
            { typeof(newOrderRespType), (int)ResponeTypeIds.NewOrderResp },
            { typeof(profileRespType), (int)ResponeTypeIds.ProfileResp },
            { typeof(quickRespType), (int)ResponeTypeIds.QuickResp },
            { typeof(quickRespType_old), (int)ResponeTypeIds.QuickResponse },
            { typeof(reversalRespType), (int)ResponeTypeIds.ReversalResp },
            { typeof(safetechFraudAnalysisRespType), (int)ResponeTypeIds.SafetechFraudAnalysisResp },
        };
    }
}