using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PaymentechCore.Models.RequestModels
{
    [Serializable]
    public class ClientRequest
    {
        public Request Request { get; set; }
        public string TraceNumber { get; set; }
        public bool PreviousRequest { get; set; }

        public ClientRequest DeepCopy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;

                return (ClientRequest) formatter.Deserialize(ms);
            }
        }
    }
}