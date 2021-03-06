﻿using Newtonsoft.Json;
using PaymentechCore.Models.RequestModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentechCore.Models.RequestModels
{
    public class SafetechFraudAnalysisType : safetechFraudAnalysisType
    {
        public safetechFraudAnalysisType CopyToBase()
        {
            string json = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<safetechFraudAnalysisType>(json);
        }
    }
}