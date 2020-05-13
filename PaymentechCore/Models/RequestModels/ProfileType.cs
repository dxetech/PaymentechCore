using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class ProfileType
    {
        public ProfileType() { }

        public ProfileType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            Valid_Routing_Bins customerBin = Valid_Routing_Bins.Item000002) : base()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            CustomerMerchantID = customerMerchantID;
            CustomerBin = customerBin;
        }

        public static ProfileType CreateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            Valid_Routing_Bins customerBin = Valid_Routing_Bins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = Profile_Action_Types.C;

            profile.CustomerCountryCode = customerCountryCode;
            profile.CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            profile.CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            profile.CustomerAccountType = customerAccountType;
            profile.Status = status;

            return profile;
        }

        public static ProfileType ReadProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            Valid_Routing_Bins customerBin = Valid_Routing_Bins.Item000002)
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = Profile_Action_Types.R;

            return profile;
        }

        public static ProfileType UpdateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            Valid_Routing_Bins customerBin = Valid_Routing_Bins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = Profile_Action_Types.U;

            profile.CustomerCountryCode = customerCountryCode;
            profile.CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            profile.CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            profile.CustomerAccountType = customerAccountType;
            profile.Status = status;

            return profile;
        }

        public static ProfileType DestroyProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            Valid_Routing_Bins customerBin = Valid_Routing_Bins.Item000002)
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = Profile_Action_Types.D;

            return profile;
        }
    }
}