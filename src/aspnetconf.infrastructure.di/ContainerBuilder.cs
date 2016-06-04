using Microsoft.Extensions.Configuration;
using Autofac;
using Nest;
using System;

namespace aspnetconf.infrastructure.di
{
    public class ContainerBuilder
    {
        public static Autofac.ContainerBuilder Configure(IConfigurationRoot config)
        {
            var container = new Autofac.ContainerBuilder();
            container.RegisterInstance(new ElasticClient(new Uri(config.GetSection("ESAddress").Value))).As<IElasticClient>();
            return container;
        }

    }
}
