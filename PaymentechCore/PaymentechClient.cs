using System;
using Microsoft.Extensions.Options;
using PaymentechCore.Models;
using RestSharp;

namespace PaymentechCore
{
    public class PaymentechClientOptions
    {
        public Credentials Credentials { get; set; }
        public bool Production { get; set; }
    }

    public class PaymentechClient
    {
        private readonly PaymentechClientOptions _options;
        private readonly Endpoint _endpoint;

        public PaymentechClient(IOptions<PaymentechClientOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
            _endpoint = new Endpoint(_options.Credentials, _options.Production);
        }

        public Models.ResponseModels.accountUpdaterRespType UpdateAccount(Models.RequestModels.accountUpdaterType accountUpdate)
        {
            var client = new RestClient(_endpoint.Url());

            var xmlBody = new Models.RequestModels.Request { Item = accountUpdate };
            var request = new RestRequest("", Method.POST);
            request.AddXmlBody(xmlBody);
            var response = client.Execute<Models.ResponseModels.accountUpdaterRespType>(request);
            return response.Data;
        }

        public Models.ResponseModels.endOfDayRespType EndOfDay(Models.RequestModels.endOfDayType endOfDay)
        {
            var client = 
        }
    }
}