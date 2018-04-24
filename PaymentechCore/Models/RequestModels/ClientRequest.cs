using System;

namespace PaymentechCore.Models.RequestModels
{
    public class ClientRequest
    {
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
    }
}