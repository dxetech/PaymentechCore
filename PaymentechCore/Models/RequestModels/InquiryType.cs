﻿using Newtonsoft.Json;
using PaymentechCore.Models.RequestModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentechCore.Models.RequestModels
{
    public class InquiryType : inquiryType
    {
        public inquiryType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<inquiryType>(json);
        }
    }
}