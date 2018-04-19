using System;
using System.Collections.Generic;
using System.Text;
using PaymentechCore.Models.RequestModels;

namespace PaymentechCore
{
    public class PaymentechConstants
    {
        public enum PaymentechProfileActionTypes
        {
            Create,
            Read,
            Update,
            Destroy,
        }

        public const string PROCSTATUS_INVALID_RETRY_TRACE = "9714";
        public const string PROCSTATUS_USER_NOT_FOUND = "9581";
        public const string CARD_TYPE_VISA = "VISA";
        public const string CARD_TYPE_MC = "MC";
        public const string CARD_TYPE_AMEX = "Amex";
        public const string CARD_TYPE_DISCOVER = "Discover";
        public const string CARD_TYPE_JCB = "JCB";
        public static List<string> CARD_TYPES = new List<string>
        {
            CARD_TYPE_VISA,
            CARD_TYPE_MC,
            CARD_TYPE_AMEX,
            CARD_TYPE_DISCOVER,
            CARD_TYPE_JCB,
        };
        public const string TEST_ENDPOINT_URL_1 = "https://orbitalvar1.chasepaymentech.com";
        public const string TEST_ENDPOINT_URL_2 = "https://orbitalvar2.chasepaymentech.com";
        public const string ENDPOINT_URL_1 = "https://orbital1.chasepaymentech.com";
        public const string ENDPOINT_URL_2 = "https://orbital2.chasepaymentech.com";
        public const string CURRENT_DTD_VERSION = "PTI68";
        public static Dictionary<string, string> AUTH_PLATFORM_BIN = new Dictionary<string, string>
        {
            { "salem", "000001" },
            { "pns", "000002" },
        };
        public static Dictionary<PaymentechProfileActionTypes, ProfileActionTypes> PaymentechProfileActions = new Dictionary<PaymentechProfileActionTypes, ProfileActionTypes>
        {
            { PaymentechProfileActionTypes.Create, ProfileActionTypes.C },
            { PaymentechProfileActionTypes.Read, ProfileActionTypes.R },
            { PaymentechProfileActionTypes.Update, ProfileActionTypes.U },
            { PaymentechProfileActionTypes.Destroy, ProfileActionTypes.D },
        };
    }
}
