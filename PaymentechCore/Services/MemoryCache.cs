using System;
using System.Collections.Generic;

namespace PaymentechCore.Services
{
    public class MemoryCache : IPaymentechCache
    {
        private Dictionary<string, string> _dict = new Dictionary<string, string>();

        public string GetValue(string key)
        {
            return _dict.ContainsKey(key) ? _dict[key] : null;
        }

        public void SetValue(string key, string value)
        {
            _dict[key] = value;
        }
    }
}