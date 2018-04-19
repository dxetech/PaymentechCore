using System;
using Xunit;
using PaymentechCore.Services;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using Microsoft.Extensions.Options;
using PaymentechCore;
using static PaymentechCore.PaymentechConstants;

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
            profile.CCExpireDate = "1120";

            return profile;
        }

        [Fact]
        public void ProfileLifecycle()
        {
            var createProfile = SetProfileDefaults(ProfileType.CreateProfile(_credentials.Username, _credentials.Password));

            // Profile creation
            var createResult = _client.Profile(createProfile);
            Assert.NotNull(createResult?.Response?.Data);
            var createData = createResult.Response.Data;
            Assert.Equal("0", createData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(createData.CustomerRefNum));
            Assert.Equal(createProfile.CustomerName, createData.CustomerName);
            Assert.Equal(createProfile.CustomerAddress1, createData.CustomerAddress1);
            Assert.Equal(createProfile.CustomerAddress2, createData.CustomerAddress2);
            Assert.Equal(createProfile.CustomerCity, createData.CustomerCity);
            Assert.Equal(createProfile.CustomerState, createData.CustomerState);
            Assert.Equal(createProfile.CustomerZIP, createData.CustomerZIP);
            Assert.Equal(createProfile.CustomerEmail, createData.CustomerEmail);
            Assert.Equal(createProfile.CustomerPhone, createData.CustomerPhone);
            Assert.Equal(createProfile.CCAccountNum, createData.CCAccountNum);
            Assert.Equal(createProfile.CCExpireDate, createData.CCExpireDate);
            var customerRefNum = createData.CustomerRefNum;

            // Profile reading
            var readProfile = SetProfileDefaults(ProfileType.ReadProfile(_credentials.Username, _credentials.Password));
            readProfile.CustomerRefNum = customerRefNum;
            var readResult = _client.Profile(readProfile);
            Assert.NotNull(readResult?.Response?.Data);
            var readData = readResult.Response.Data;
            Assert.Equal("0", readData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(readData.CustomerRefNum));
            Assert.Equal(readProfile.CustomerName, readData.CustomerName);
            Assert.Equal(readProfile.CustomerAddress1, readData.CustomerAddress1);
            Assert.Equal(readProfile.CustomerAddress2, readData.CustomerAddress2);
            Assert.Equal(readProfile.CustomerCity, readData.CustomerCity);
            Assert.Equal(readProfile.CustomerState, readData.CustomerState);
            Assert.Equal(readProfile.CustomerZIP, readData.CustomerZIP);
            Assert.Equal(readProfile.CustomerEmail, readData.CustomerEmail);
            Assert.Equal(readProfile.CustomerPhone, readData.CustomerPhone);
            Assert.Equal(readProfile.CCAccountNum, readData.CCAccountNum);
            Assert.Equal(readProfile.CCExpireDate, readData.CCExpireDate);

            // Profile updating
            var updateProfile = SetProfileDefaults(ProfileType.UpdateProfile(_credentials.Username, _credentials.Password));
            updateProfile.CustomerRefNum = customerRefNum;
            updateProfile.CustomerName = "Example Customer";
            updateProfile.CustomerCity = "Philadelphia";
            updateProfile.CustomerState = "PA";
            updateProfile.CustomerZIP = "19130";
            var updateResult = _client.Profile(updateProfile);
            Assert.NotNull(updateResult?.Response?.Data);
            var updateData = updateResult.Response.Data;
            Assert.Equal("0", updateData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(updateData.CustomerRefNum));
            Assert.Equal("Example Customer", updateData.CustomerName);
            Assert.Equal(updateProfile.CustomerAddress1, updateData.CustomerAddress1);
            Assert.Equal(updateProfile.CustomerAddress2, updateData.CustomerAddress2);
            Assert.Equal("Philadelphia", updateData.CustomerCity);
            Assert.Equal("PA", updateData.CustomerState);
            Assert.Equal("19130", updateData.CustomerZIP);
            Assert.Equal(updateProfile.CustomerEmail, updateData.CustomerEmail);
            Assert.Equal(updateProfile.CustomerPhone, updateData.CustomerPhone);
            Assert.Equal(updateProfile.CCAccountNum, updateData.CCAccountNum);
            Assert.Equal(updateProfile.CCExpireDate, updateData.CCExpireDate);

            // Profile deletion
            var deleteProfile = SetProfileDefaults(ProfileType.DestroyProfile(_credentials.Username, _credentials.Password));
            deleteProfile.CustomerRefNum = customerRefNum;
            var deleteResult = _client.Profile(deleteProfile);
            Assert.NotNull(deleteResult?.Response?.Data);
            var deleteData = updateResult.Response.Data;
            Assert.Equal("0", deleteData.ProfileProcStatus);
            Assert.Equal(customerRefNum, deleteData.CustomerRefNum);
        }
    }
}