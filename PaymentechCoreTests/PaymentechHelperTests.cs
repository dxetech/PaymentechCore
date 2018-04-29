using System;
using Xunit;
using PaymentechCore.Services;

namespace PaymentechCoreTests
{
    public class PaymentechHelperTests
    {
        [Fact]
        public void PaymentAmounts()
        {
            var amount1 = "144";
            var convertedAmount1 = PaymentechHelpers.ConvertAmount(amount1);
            Assert.Equal("14400", convertedAmount1);

            var amount2 = "13.2";
            var convertedAmount2 = PaymentechHelpers.ConvertAmount(amount2);
            Assert.Equal("1320", convertedAmount2);

            var amount3 = "9.90";
            var convertedAmount3 = PaymentechHelpers.ConvertAmount(amount3);
            Assert.Equal("990", convertedAmount3);
        }
    }
}