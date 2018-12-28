using PlaceHolderParsingAPI.Parsing.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PlaceHolderParsingAPI.Parsing
{
    public class AppModule_Parsing
    {
        public AppModule_Parsing(IServiceCollection services)
        {
            services.AddTransient<WebClient.IWebClient, WebClient.WebClient>();
            services.AddTransient<IParsingService, ParsingService>();
        }
        
    }
}
