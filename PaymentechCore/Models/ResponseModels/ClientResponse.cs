using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PaymentechCore.Models.ResponseModels
{
    [Serializable]
    public class ClientResponse
    {
        public Response Response { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }
        public string PreviousResponse { get; set; }
        public string ProcStatus { get; set; }

        public ClientResponse DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (ClientResponse) formatter.Deserialize(ms);
            }
        }
    }
}