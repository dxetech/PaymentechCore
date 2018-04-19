using System;

namespace PaymentechCore.Models.RequestModels
{
    public partial class ProfileType
    {
        public static ProfileType CreateProfile()
        {
            var profile = new ProfileType();
            profile.CustomerProfileAction = ProfileActionTypes.C;

            profile.CustomerBin = ValidRoutingBins.Item000002;
            profile.CustomerCountryCode = "US";
            profile.CustomerProfileOrderOverrideInd = "NO";
            profile.CustomerProfileFromOrderInd = "A";
            profile.CustomerAccountType = "CC";
            profile.Status = "A";

            return profile;
        }

        public static ProfileType ReadProfile()
        {
            var profile = new ProfileType();
            profile.CustomerProfileAction = ProfileActionTypes.R;

            return profile;
        }

        public static ProfileType UpdateProfile()
        {
            var profile = new ProfileType();
            profile.CustomerProfileAction = ProfileActionTypes.U;

            profile.CustomerCountryCode = "US";
            profile.CustomerProfileFromOrderInd = "NO";
            profile.CustomerProfileFromOrderInd = "S";
            profile.CustomerAccountType = "CC";
            profile.Status = "A";

            return profile;
        }

        public static ProfileType DestroyProfile()
        {
            var profile = new ProfileType();
            profile.CustomerProfileAction = ProfileActionTypes.D;

            return profile;
        }
    }
}