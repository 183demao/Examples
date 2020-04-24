using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace System
{
    public static class IocManager
    {
        public static IServiceCollection Services { get; private set; }

        public static IServiceProvider Instance { get; private set; }

        public static IConfiguration Configuration { get; private set; }


        static IocManager()
        {
            Services = new ServiceCollection();

            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }


        public static void Build()
        {
            if (Instance != null)
            {
                return;
            }

            Instance = Services.BuildServiceProvider();
        }
    }
}
