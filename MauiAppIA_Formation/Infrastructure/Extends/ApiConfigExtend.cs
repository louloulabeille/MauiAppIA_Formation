using MauiAppIA_Formation.Infrastructure.ModelConfiguration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppIA_Formation.Infrastructure.Extends
{
    public static class ApiConfigExtend
    {
        extension(IServiceCollection services)
        {
            /// <summary>
            /// Ajout du package Microsoft.Extensions.Options 
            /// Microsoft.Extensions.Options.ConfigurationExtensions
            /// pour prendre en compte l'injection de dépendance avec Ioptions
            /// </summary>
            /// <param name="configuration"></param>
            /// <returns></returns>
            public IServiceCollection AddApiConfig(IConfiguration configuration)
            {
                services.Configure<ApiConfig>(configuration.GetSection("Api"));
                return services;
            }
        }

        extension(IConfigurationBuilder builder)
        {
            /// <summary>
            /// Récupération du fichier json appsetting dans "resources raw"
            /// et injection dans builder.configuration
            /// installer Microsoft.Extensions.Configuration.Json
            /// </summary>
            /// <returns></returns>
            public IConfigurationBuilder AddApiConfigJson()
            {
                using var stream = FileSystem.OpenAppPackageFileAsync("ApiJsconfig.json").Result;
                var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
                builder.AddConfiguration(config);
                return builder;
            }

        }
}
}
