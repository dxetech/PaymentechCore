using System;
using RestSharp;

namespace PaymentechCore.Models.RequestModels
{
    public class ClientResponse<T>
    {
        public IRestResponse<T> Response { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}