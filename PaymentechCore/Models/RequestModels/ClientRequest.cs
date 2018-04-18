using System;
using RestSharp;

namespace PaymentechCore.Models.RequestModels
{
    public class ClientRequest
    {
        public RestRequest Request { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}