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
            { typeof(AccountUpdaterRespType), (int)ResponeTypeIds.AccountUpdaterResp },
            { typeof(EndOfDayRespType), (int)ResponeTypeIds.EndOfDayResp },
            { typeof(FlexCacheRespType), (int)ResponeTypeIds.FlexCacheResp },
            { typeof(InquiryRespType), (int)ResponeTypeIds.InquiryResp },
            { typeof(MarkForCaptureRespType), (int)ResponeTypeIds.MarkForCaptureResp },
            { typeof(NewOrderRespType), (int)ResponeTypeIds.NewOrderResp },
            { typeof(ProfileRespType), (int)ResponeTypeIds.ProfileResp },
            { typeof(QuickRespType), (int)ResponeTypeIds.QuickResp },
            { typeof(QuickRespType_Old), (int)ResponeTypeIds.QuickResponse },
            { typeof(ReversalRespType), (int)ResponeTypeIds.ReversalResp },
            { typeof(SafetechFraudAnalysisRespType), (int)ResponeTypeIds.SafetechFraudAnalysisResp },
        };
    }
}