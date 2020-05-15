using System;
using Xunit;
using PaymentechCore.Services;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;
using Microsoft.Extensions.Options;
using PaymentechCore;
using static PaymentechCore.PaymentechConstants;
using PaymentechCore.Models.ResponseModels.BaseModels;

namespace PaymentechCoreTests
{
    public class ProfileTests
    {
        private readonly IPaymentechClient _client;
        private readonly Credentials _credentials;

        public ProfileTests()
        {
            _client = new PaymentechTestClient();
            _credentials = _client.Credentials();
        }

        public static ProfileType SetProfileDefaults(ProfileType profile)
        {
            profile.CustomerName = "Test User";
            profile.CustomerAddress1 = "101 Main St.";
            profile.CustomerAddress2 = "Apt. 4";
            profile.CustomerCity = "New York";
            profile.CustomerState = "NY";
            profile.CustomerZIP = "10012";
            profile.CustomerEmail = "test@example.com";
            profile.CustomerPhone = "9089089080";
            profile.CCAccountNum = "4788250000028291";
            profile.CCExpireDate = "1124";

            return profile;
        }

        [Fact]
        public void ProfileLifecycle()
        {
            var createProfile = SetProfileDefaults(new CreateProfileType(_credentials.Username, _credentials.Password, _credentials.MerchantId));

            // Profile creation
            var createResult = _client.Profile(createProfile);
            Assert.NotNull(createResult?.Response?.Item);
            var createData = (profileRespType)createResult.Response.Item;
            Assert.Equal("0", createData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(createData.CustomerRefNum));
            Assert.Equal(createProfile.CustomerName.ToUpper(), createData.CustomerName.ToUpper());
            Assert.Equal(createProfile.CustomerAddress1.ToUpper(), createData.CustomerAddress1.ToUpper());
            Assert.Equal(createProfile.CustomerAddress2.ToUpper(), createData.CustomerAddress2.ToUpper());
            Assert.Equal(createProfile.CustomerCity.ToUpper(), createData.CustomerCity.ToUpper());
            Assert.Equal(createProfile.CustomerState.ToUpper(), createData.CustomerState.ToUpper());
            Assert.Equal(createProfile.CustomerZIP.ToUpper(), createData.CustomerZIP.ToUpper());
            Assert.Equal(createProfile.CustomerEmail.ToUpper(), createData.CustomerEmail.ToUpper());
            Assert.Equal(createProfile.CustomerPhone.ToUpper(), createData.CustomerPhone.ToUpper());
            Assert.Equal(createProfile.CCAccountNum.ToUpper(), createData.CCAccountNum.ToUpper());
            Assert.Equal(createProfile.CCExpireDate.ToUpper(), createData.CCExpireDate.ToUpper());
            var customerRefNum = createData.CustomerRefNum;

            // Profile reading
            var readProfile = SetProfileDefaults(new ReadProfileType(_credentials.Username, _credentials.Password, _credentials.MerchantId));
            readProfile.CustomerRefNum = customerRefNum;
            readProfile.CCAccountNum = string.Empty;
            var readResult = _client.Profile(readProfile);
            Assert.NotNull(readResult?.Response?.Item);
            var readData = (profileRespType)readResult.Response.Item;
            Assert.Equal("0", readData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(readData.CustomerRefNum));
            Assert.Equal(readProfile.CustomerName.ToUpper(), readData.CustomerName.ToUpper());
            Assert.Equal(readProfile.CustomerAddress1.ToUpper(), readData.CustomerAddress1.ToUpper());
            Assert.Equal(readProfile.CustomerAddress2.ToUpper(), readData.CustomerAddress2.ToUpper());
            Assert.Equal(readProfile.CustomerCity.ToUpper(), readData.CustomerCity.ToUpper());
            Assert.Equal(readProfile.CustomerState.ToUpper(), readData.CustomerState.ToUpper());
            Assert.Equal(readProfile.CustomerZIP.ToUpper(), readData.CustomerZIP.ToUpper());
            Assert.Equal(readProfile.CustomerEmail.ToUpper(), readData.CustomerEmail.ToUpper());
            Assert.Equal(readProfile.CustomerPhone.ToUpper(), readData.CustomerPhone.ToUpper());
            Assert.Equal(readProfile.CCExpireDate.ToUpper(), readData.CCExpireDate.ToUpper());

            // Profile updating
            var updateProfile = SetProfileDefaults(new UpdateProfileType(_credentials.Username, _credentials.Password, _credentials.MerchantId));
            updateProfile.CustomerRefNum = customerRefNum;
            updateProfile.CCAccountNum = string.Empty;
            updateProfile.CustomerName = "Example Customer";
            updateProfile.CustomerCity = "Philadelphia";
            updateProfile.CustomerState = "PA";
            updateProfile.CustomerZIP = "19130";
            var updateResult = _client.Profile(updateProfile);
            Assert.NotNull(updateResult?.Response?.Item);
            var updateData = (profileRespType)updateResult.Response.Item;
            Assert.Equal("0", updateData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(updateData.CustomerRefNum));
            Assert.Equal("Example Customer".ToUpper(), updateData.CustomerName.ToUpper());
            Assert.Equal(updateProfile.CustomerAddress1.ToUpper(), updateData.CustomerAddress1.ToUpper());
            Assert.Equal(updateProfile.CustomerAddress2.ToUpper(), updateData.CustomerAddress2.ToUpper());
            Assert.Equal("Philadelphia".ToUpper(), updateData.CustomerCity.ToUpper());
            Assert.Equal("PA".ToUpper(), updateData.CustomerState.ToUpper());
            Assert.Equal("19130".ToUpper(), updateData.CustomerZIP.ToUpper());
            Assert.Equal(updateProfile.CustomerEmail.ToUpper(), updateData.CustomerEmail.ToUpper());
            Assert.Equal(updateProfile.CustomerPhone.ToUpper(), updateData.CustomerPhone.ToUpper());
            Assert.Equal(updateProfile.CCExpireDate.ToUpper(), updateData.CCExpireDate.ToUpper());

            // Profile deletion
            var deleteProfile = SetProfileDefaults(new DestroyProfileType(_credentials.Username, _credentials.Password, _credentials.MerchantId));
            deleteProfile.CustomerRefNum = customerRefNum;
            deleteProfile.CCAccountNum = string.Empty;
            var deleteResult = _client.Profile(deleteProfile);
            Assert.NotNull(deleteResult?.Response?.Item);
            var deleteData = (profileRespType)updateResult.Response.Item;
            Assert.Equal("0", deleteData.ProfileProcStatus);
            Assert.Equal(customerRefNum, deleteData.CustomerRefNum);
        }
    }
}