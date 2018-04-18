using System;
using System.Collections.Generic;
using System.Text;
using PaymentechCore;

namespace PaymentechCore.Models
{
    public class Endpoint
    {
        private readonly bool _production;
        public Credentials Credentials { get; }
        // there are 2 platform options defined in the orbital gateway chase
        // Salem - BIN 000001
        // PNS - BIN 000002
        private readonly string _platform;

        public Endpoint(Credentials credentials, bool production = false, string platform = "pns")
        {
            Credentials = credentials;
            _production = production;
            // only set the platform if it is valid
            if (!string.IsNullOrEmpty(platform) &&
                PaymentechConstants.AUTH_PLATFORM_BIN.ContainsKey(platform))
            {
                _platform = platform;
            }
        }

        public string Url()
        {
            return _production ? PaymentechConstants.ENDPOINT_URL_1 : PaymentechConstants.TEST_ENDPOINT_URL_1;
        }

        public string Url2()
        {
            return _production ? PaymentechConstants.ENDPOINT_URL_2 : PaymentechConstants.TEST_ENDPOINT_URL_2;
        }

        public string PlatformBin()
        {
            return PaymentechConstants.AUTH_PLATFORM_BIN[_platform];
        }
    }
}
