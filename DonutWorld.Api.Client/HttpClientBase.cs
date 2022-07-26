using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonutWorld.Api.Client
{
    public class HttpClientBase : Abstractions.IHttpClientBase
    {
        private readonly IConfiguration _configuration;

        public HttpClientBase(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public string BaseUrl => _configuration.GetSection("DonutWorld.Api.BaseUrl").Value;
    }
}
