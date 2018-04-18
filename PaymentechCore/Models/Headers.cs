using System;
using System.Collections.Generic;
using PaymentechCore;

namespace PaymentechCore.Models
{
    public class Headers
    {
        public string MIME_Version { get; set; }
        public string ContentTransferEncoding { get; set; }
        public string RequestNumber { get; set; }
        public string DocumentType { get; set; }
        public string TraceNumber { get; set; }
        public string InterfaceVersion { get; set; }
        public string MerchantID { get; set; }

        public Headers(
            string traceNumber,
            string interfaceVersion,
            string merchantID,
            string mimeVersion = "1.1",
            string contentTransferEncoding = "text",
            string requestNumber = "1",
            string documentType = "Request")
        {
            TraceNumber = traceNumber;
            InterfaceVersion = interfaceVersion;
            MerchantID = merchantID;
            MIME_Version = mimeVersion;
            ContentTransferEncoding = contentTransferEncoding;
            RequestNumber = requestNumber;
            DocumentType = documentType;
        }

        public Dictionary<string, string> ToDictionary()
        {
            return new Dictionary<string, string>
            {
                { "MIME-Version", MIME_Version },
                { "Content-type", ContentType() },
                { "Content-transfer-encoding", ContentTransferEncoding },
                { "Request-number", RequestNumber },
                { "Document-type", DocumentType },
                { "Trace-number", TraceNumber },
                { "Interface-Version", InterfaceVersion },
                { "MerchantID", MerchantID },
            };
        }

        public string ContentType()
        {
            return $"application/{PaymentechConstants.CURRENT_DTD_VERSION}";
        }
    }
}