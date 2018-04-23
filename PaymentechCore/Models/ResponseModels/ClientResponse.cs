using System;
using RestSharp;

namespace PaymentechCore.Models.ResponseModels
{
    public class ClientResponse
    {
        public Response Response { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}