using System;
using Flurl.Http;
using RestSharp;

namespace PaymentechCore.Models.RequestModels
{
    public class ClientRequest
    {
        public IFlurlRequest Request { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}