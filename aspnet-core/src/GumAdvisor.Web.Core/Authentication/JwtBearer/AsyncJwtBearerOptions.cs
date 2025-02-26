using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GumAdvisor.Web.Authentication.JwtBearer
{
    public class AsyncJwtBearerOptions : JwtBearerOptions
    {
        public readonly List<IAsyncSecurityTokenValidator> AsyncSecurityTokenValidators;
        
        private readonly GumAdvisorAsyncJwtSecurityTokenHandler _defaultAsyncHandler = new GumAdvisorAsyncJwtSecurityTokenHandler();

        public AsyncJwtBearerOptions()
        {
            AsyncSecurityTokenValidators = new List<IAsyncSecurityTokenValidator>() {_defaultAsyncHandler};
        }
    }

}
