using System;
using System.Collections.Generic;
using System.Text;
using PaymentechCore;

namespace PaymentechCore.Models
{
    public class Endpoint
    {
        public bool Production { get; set; }
        // there are 2 platform options defined in the orbital gateway chase
        // Salem - BIN 000001
        // PNS - BIN 000002
        public string Platform { get; set; }

        public Endpoint() { }

        public Endpoint(bool production = false, string platform = "pns") : this()
        {
            Production = production;
            // only set the platform if it is valid
            if (!string.IsNullOrEmpty(platform) &&
                PaymentechConstants.AUTH_PLATFORM_BIN.ContainsKey(platform))
            {
                Platform = platform;
            }
        }

        public string Url()
        {
            return Production ? PaymentechConstants.ENDPOINT_URL_1 : PaymentechConstants.TEST_ENDPOINT_URL_1;
        }

        public string Url2()
        {
            return Production ? PaymentechConstants.ENDPOINT_URL_2 : PaymentechConstants.TEST_ENDPOINT_URL_2;
        }

        public string PlatformBin()
        {
            return PaymentechConstants.AUTH_PLATFORM_BIN[Platform];
        }
    }
}
