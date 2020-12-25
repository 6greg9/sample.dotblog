﻿using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Mvc5Net48.Message;

namespace Mvc5Net48
{
    public class DependencyInjectionConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var services = ConfigureServices();

            var provider = services.BuildServiceProvider();

            var resolver = new DefaultDependencyResolver(provider);
            var resolver2 = new DefaultDependencyResolver2(provider);
            //DependencyResolver.SetResolver(resolver);
            DependencyResolver.SetResolver(resolver2);
            ServiceScopeModule.SetServiceProvider(provider);

            //config.DependencyResolver = resolver;
        }

        /// <summary>
        ///     使用 MS DI 註冊
        /// </summary>
        /// <returns></returns>
        private static ServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            //使用 Microsoft.Extensions.DependencyInjection 註冊
            services.AddControllersAsServices(typeof(DependencyInjectionConfig)
                                              .Assembly
                                              .GetExportedTypes()
                                              .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                                              .Where(t => typeof(IHttpController).IsAssignableFrom(t)
                                                          || t.Name.EndsWith("Controller",
                                                                             StringComparison.OrdinalIgnoreCase)));

            services.AddScoped<IMessager, LogMessager>();

            services.AddTransient<ITransientMessager, MultiMessager>()
                    .AddSingleton<ISingleMessager, MultiMessager>()
                    .AddScoped<IScopeMessager, MultiMessager>();
            return services;
        }
    }
}