using Xunit;
using PaymentechCore.Services;
using PaymentechCore.Models;
using PaymentechCore.Models.RequestModels;
using PaymentechCore.Models.ResponseModels;
using PaymentechCore.Models.ResponseModels.BaseModels;
using PaymentechCore.Models.RequestModels.BaseModels;

namespace PaymentechCoreTests
{
    public class OrderTests
    {
        private readonly IPaymentechClient _client;
        private readonly Credentials _credentials;

        public OrderTests()
        {
            _client = new PaymentechTestClient();
            _credentials = _client.Credentials;
        }

        [Fact]
        public void ProfileOrder()
        {
            var profile = ProfileTests.SetProfileDefaults(new CreateProfileType(_credentials.Username, _credentials.Password, _credentials.MerchantId));
            var profileResult = _client.Profile(profile);
            Assert.NotNull(profileResult?.Response?.Item);
            var profileItem = (profileRespType)profileResult.Response.Item;
            Assert.Equal("0", profileItem.ProfileProcStatus);
            Assert.False(string.IsNullOrEmpty(profileItem.CustomerRefNum));
            var customerRefNum = profileItem.CustomerRefNum;
            var order = new NewOrderType(_credentials.Username, _credentials.Password, _credentials.MerchantId)
            {
                CustomerRefNum = customerRefNum,
                OrderID = "100001",
                Amount = PaymentechHelpers.ConvertAmount(10.00m),
            };
            var orderResult = _client.NewOrder(order);
            Assert.NotNull(orderResult?.Response?.Item);
            var orderItem = (newOrderRespType)orderResult.Response.Item;
            Assert.Equal("0", orderItem.ProcStatus);
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
                AVSphoneNum = "9089089080",
                AccountNum = "4788250000028291",
                Exp = "1124",
                MessageType = validtranstypes.AC,
            };

            var orderResult = _client.NewOrder(order);
            Assert.NotNull(orderResult?.Response?.Item);
            var orderItem = (newOrderRespType)orderResult.Response.Item;
            Assert.Equal("0", orderItem.ProcStatus);
        }

        [Fact]
        public void Duplicate_CC_Order()
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
                AVSphoneNum = "9089089080",
                AccountNum = "4788250000028291",
                Exp = "1124",
                MessageType = validtranstypes.AC,
            };

            var traceNumber = _client.NewTraceNumber();
            var cache = _client.GetCache();
            var previousResponse = cache.GetValue(traceNumber);
            Assert.Null(previousResponse);

            var orderResult = _client.NewOrder(order, traceNumber);
            Assert.NotNull(orderResult?.Response?.Item);
            var orderItem = (newOrderRespType)orderResult.Response.Item;
            Assert.Equal("0", orderItem.ProcStatus);

            previousResponse = cache.GetValue(traceNumber);
            Assert.NotNull(previousResponse);

            var duplicateOrderResult = _client.NewOrder(order, traceNumber);
            Assert.NotNull(orderResult?.Response?.Item);
            var duplicateOrderItem = (newOrderRespType)duplicateOrderResult.Response.Item;
            Assert.Equal("0", duplicateOrderItem.ProcStatus);

            var duplicatePreviousResponse = cache.GetValue(traceNumber);
            Assert.NotNull(duplicatePreviousResponse);
            Assert.Equal(previousResponse, duplicatePreviousResponse);
        }
    }
}