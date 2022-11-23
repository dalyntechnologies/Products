using Microsoft.Extensions.Configuration;
using Products.Web.Services.Interfaces;
using System.ComponentModel.Design;

namespace Products.Web.Services
{
    public class HelperService : IHelperService
    {
        private IConfiguration _configuration;
        public HelperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetBaseUrl()
        {
            return _configuration["ConnectionStrings:ServiceUrl"];
        }
    }
}
