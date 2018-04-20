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
    public class OrderTests
    {
        private readonly IPaymentechClient _client;
        private readonly Credentials _credentials;

        public OrderTests()
        {
            _client = new PaymentechTestClient();
            _credentials = _client.Credentials();
        }

        [Fact]
        public void ProfileOrder()
        {
            var profile = ProfileTests.SetProfileDefaults(ProfileType.CreateProfile(_credentials.Username, _credentials.Password, _credentials.MerchantId));
            var profileResult = _client.Profile(profile);
            Assert.NotNull(profileResult?.Response?.Data);
            var profileData = profileResult.Response.Data;
            Assert.Equal("0", profileData.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(profileData.CustomerRefNum));
            var customerRefNum = profileData.CustomerRefNum;
            var order = new NewOrderType(_credentials.Username, _credentials.Password, _credentials.MerchantId)
            {
                CustomerRefNum = customerRefNum,
                OrderID = "100001",
                Amount = PaymentechHelpers.ConvertAmount(10.00m),
            };
            var orderResult = _client.NewOrder(order);
            Assert.NotNull(orderResult?.Response?.Data);
            var orderData = orderResult.Response.Data;
            Assert.Equal("0", orderData.ProcStatus);
        }

        [Fact]
        public void CC_Order()
        {
            var order = new NewOrderType(_credentials.Username, _credentials.Password, _credentials.MerchantId)
            {
                OrderID = "100001",
                Amount = PaymentechHelpers.ConvertAmount(10.00m),
                AVSaddress1 = "101 Main St.",
                AVSaddress2 = "Apt. 4",
                AVScity = "New York",
                AVSstate = "NY",
                AVSzip = "10012",
                CustomerEmail = "test@example.com",
                AVSPhoneType = "9089089080",
                AccountNum = "4788250000028291",
                Exp = "1120",
                MessageType = ValidTransTypes.AC,
            };

            var orderResult = _client.NewOrder(order);
            Assert.NotNull(orderResult?.Response?.Data);
            var orderData = orderResult.Response.Data;
            Assert.Equal("0", orderData.ProcStatus);
        }
    }
}