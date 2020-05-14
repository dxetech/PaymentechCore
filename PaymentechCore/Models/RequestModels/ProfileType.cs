using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class profileType
    {
        public profileType() { }

        public profileType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            validroutingbins customerBin = validroutingbins.Item000002) : base()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            CustomerMerchantID = customerMerchantID;
            CustomerBin = customerBin;
        }

        public static profileType CreateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            validroutingbins customerBin = validroutingbins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new profileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = profileactiontypes.C;

            profile.CustomerCountryCode = customerCountryCode;
            profile.CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            profile.CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            profile.CustomerAccountType = customerAccountType;
            profile.Status = status;

            return profile;
        }

        public static profileType ReadProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            validroutingbins customerBin = validroutingbins.Item000002)
        {
            var profile = new profileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = profileactiontypes.R;

            return profile;
        }

        public static profileType UpdateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            validroutingbins customerBin = validroutingbins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new profileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = profileactiontypes.U;

            profile.CustomerCountryCode = customerCountryCode;
            profile.CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            profile.CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            profile.CustomerAccountType = customerAccountType;
            profile.Status = status;

            return profile;
        }

        public static profileType DestroyProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            string customerMerchantID,
            validroutingbins customerBin = validroutingbins.Item000002)
        {
            var profile = new profileType(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin);
            profile.CustomerProfileAction = profileactiontypes.D;

            return profile;
        }
    }
}