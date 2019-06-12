using System;
using PaymentechCore.Models;
using PaymentechCore.Services;
using Xunit;

namespace PaymentechCoreTests
{
    public class ClientTests
    {
        private readonly IPaymentechClient _client;
        private readonly Credentials _credentials;

        public ClientTests()
        {
            _client = new PaymentechTestClient();
            _credentials = _client.Credentials();
        }

        [Fact]
        public void EnvSetup()
        {
            var interfaceVersion = _client.InterfaceVersion();
            Assert.True(!string.IsNullOrEmpty(interfaceVersion));
            Assert.True(!string.IsNullOrEmpty(_credentials.Username));
            Assert.True(!string.IsNullOrEmpty(_credentials.Password));
            Assert.True(!string.IsNullOrEmpty(_credentials.MerchantId));
        }
    }
}