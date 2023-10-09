using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairyManagementSystem
{
    public static class AddExtension
    {
        public static IServiceCollection AddMyExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            return services;
        }
    }
}
