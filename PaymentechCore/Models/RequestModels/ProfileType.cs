using Newtonsoft.Json;
using PaymentechCore.Models.RequestModels.BaseModels;
using System;

namespace PaymentechCore.Models.RequestModels
{
    public class ProfileType : profileType
    {
        public ProfileType() : base() { }

        public ProfileType(string orbitalConnectionUsername, string orbitalConnectionPassword, string customerMerchantID, validroutingbins customerBin = validroutingbins.Item000002) : this()
        {
            OrbitalConnectionUsername = orbitalConnectionUsername;
            OrbitalConnectionPassword = orbitalConnectionPassword;
            CustomerMerchantID = customerMerchantID;
            CustomerBin = customerBin;
        }

        public profileType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<profileType>(json);
        }
    }

    public class CreateProfileType : ProfileType
    {
        public CreateProfileType() : base() { }

        public CreateProfileType(string orbitalConnectionUsername, string orbitalConnectionPassword, string customerMerchantID, validroutingbins customerBin = validroutingbins.Item000002, string customerCountryCode = "US", string customerProfileOrderOverrideInd = "NO", string customerProfileFromOrderInd = "A", string customerAccountType = "CC", string status = "A") : base(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin)
        {
            CustomerProfileAction = profileactiontypes.C;

            CustomerCountryCode = customerCountryCode;
            CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            CustomerAccountType = customerAccountType;
            Status = status;
        }
    }

    public class ReadProfileType : ProfileType
    {
        public ReadProfileType() : base() { }

        public ReadProfileType(string orbitalConnectionUsername, string orbitalConnectionPassword, string customerMerchantID, validroutingbins customerBin = validroutingbins.Item000002) : base(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin)
        {
            CustomerProfileAction = profileactiontypes.R;
        }
    }

    public class UpdateProfileType : ProfileType
    {
        public UpdateProfileType() : base() { }

        public UpdateProfileType(string orbitalConnectionUsername, string orbitalConnectionPassword, string customerMerchantID, validroutingbins customerBin = validroutingbins.Item000002, string customerCountryCode = "US", string customerProfileOrderOverrideInd = "NO", string customerProfileFromOrderInd = "A", string customerAccountType = "CC", string status = "A") : base(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin)
        {
            CustomerProfileAction = profileactiontypes.U;

            CustomerCountryCode = customerCountryCode;
            CustomerProfileOrderOverrideInd = customerProfileOrderOverrideInd;
            CustomerProfileFromOrderInd = customerProfileFromOrderInd;
            CustomerAccountType = customerAccountType;
            Status = status;
        }
    }

    public class DestroyProfileType : ProfileType
    {
        public DestroyProfileType() : base() { }

        public DestroyProfileType(string orbitalConnectionUsername, string orbitalConnectionPassword, string customerMerchantID, validroutingbins customerBin = validroutingbins.Item000002) : base(orbitalConnectionUsername, orbitalConnectionPassword, customerMerchantID, customerBin)
        {
            CustomerProfileAction = profileactiontypes.D;
        }
    }
}