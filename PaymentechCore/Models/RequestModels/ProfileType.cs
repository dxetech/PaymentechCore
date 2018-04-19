using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class ProfileType
    {
        public ProfileType(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            ValidRoutingBins customerBin = ValidRoutingBins.Item000002)
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            CustomerBin = customerBin;
        }

        public static ProfileType CreateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            ValidRoutingBins customerBin = ValidRoutingBins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerBin);
            profile.CustomerProfileAction = ProfileActionTypes.C;

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
            ValidRoutingBins customerBin = ValidRoutingBins.Item000002)
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerBin);
            profile.CustomerProfileAction = ProfileActionTypes.R;

            return profile;
        }

        public static ProfileType UpdateProfile(
            string orbitalConnectionUsername,
            string orbitalConnectionPassword,
            ValidRoutingBins customerBin = ValidRoutingBins.Item000002,
            string customerCountryCode = "US",
            string customerProfileOrderOverrideInd = "NO",
            string customerProfileFromOrderInd = "A",
            string customerAccountType = "CC",
            string status = "A")
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerBin);
            profile.CustomerProfileAction = ProfileActionTypes.U;

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
            ValidRoutingBins customerBin = ValidRoutingBins.Item000002)
        {
            var profile = new ProfileType(orbitalConnectionUsername, orbitalConnectionPassword, customerBin);
            profile.CustomerProfileAction = ProfileActionTypes.D;

            return profile;
        }
    }
}