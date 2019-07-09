using System;

namespace PaymentechCore.Models.RequestModels
{
    public class ClientRequest
    {
        public Request Request { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}