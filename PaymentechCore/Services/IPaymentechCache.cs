using System;

namespace PaymentechCore.Services
{
    public interface IPaymentechCache
    {
        void SetValue(string key, string value);
        string GetValue(string key);
    }
}