using PlaceHolderParsingAPI.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace PlaceHolderParsingAPI.Service
{
    public class AppModule_Service
    {
        public AppModule_Service(IServiceCollection services)
        {
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
