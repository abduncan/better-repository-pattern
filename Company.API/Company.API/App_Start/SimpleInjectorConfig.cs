using Company.Domain.Commands.CreateNewUser;
using Company.Domain.Infrastructure;
using Company.Domain.Infrastructure.Repository.UserRepository;
using FluentValidation;
using MediatR;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Company.API.App_Start
{
    public class SimpleInjectorConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            // Create the dependency injection container.
            var container = new Container();
            // Set the container to by default dispose of objects after //requests.
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            // Register Simple Injector with the WebAPI Dependency Resolver.

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            ConfigureDependencies(container);
        }

        private static void ConfigureDependencies(Container container)
        {
            ConfigureMediator(container);
            ConfigureMongoDb(container);
            ConfigureDomain(container);

            container.RegisterCollection(typeof(IValidator<>), GetAssemblies());

            container.Verify();
        }

        private static void ConfigureMongoDb(Container container)
        {
            // Register mongoDb with SimpleInjector
            container.Register(() =>
            {
                // Create a connection to the mongoDb server.
                var client = new MongoClient("mongodb://localhost:27017");
                // Return a reference to the orders database.     
                return client.GetDatabase("orders");
                // Tell SimpleInjector to create one instance per request.
            }, Lifestyle.Scoped);


            // Tell mongoDb to use camal case for serialization by default.
            var pack = new ConventionPack();
            pack.Add(new CamelCaseElementNameConvention());
            ConventionRegistry.Register("pascal case", pack, t => true);

        }

        private static void ConfigureMediator(Container container)
        {
            var assemblies = GetAssemblies();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies, Lifestyle.Scoped);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies, Lifestyle.Scoped);
            container.RegisterCollection(typeof(INotificationHandler<>), assemblies);
            container.RegisterCollection(typeof(IAsyncNotificationHandler<>), assemblies);
            container.RegisterSingleton(Console.Out);
            container.RegisterSingleton(new SingleInstanceFactory(container.GetInstance));
            container.RegisterSingleton(new MultiInstanceFactory(container.GetAllInstances));

            container.RegisterDecorator(
                typeof(IAsyncRequestHandler<,>),
                typeof(ValidationHandler<,>)
                );
        }

        private static void ConfigureDomain(Container container)
        {
            var repositoryAssembly = typeof(UserRepository).Assembly;

            var registrations =
                from type in repositoryAssembly.GetExportedTypes()
                where type.Namespace.Contains("Company.Domain.Infrastructure.Repository")
                where type.GetInterfaces().Any()
                select new
                {
                    Service = type.GetInterfaces().Single(),
                    Implementation = type
                };

            foreach (var reg in registrations)
            {
                container.Register(reg.Service, reg.Implementation, Lifestyle.Scoped);
            }
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).Assembly;
            yield return typeof(WebApiApplication).Assembly;
            yield return typeof(CreateNewUserCommand).Assembly;
        }
    }
}