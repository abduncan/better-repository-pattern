using Company.Domain.Commands.CreateNewUser;
using Company.Domain.Infrastructure;
using FluentValidation;
using MediatR;
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

            container.RegisterCollection(typeof(IValidator<>), GetAssemblies());

            container.Verify();
        }

        private static void ConfigureMediator(Container container)
        {
            var assemblies = GetAssemblies();

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);
            container.Register(typeof(IAsyncRequestHandler<,>), assemblies);
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

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).Assembly;
            yield return typeof(WebApiApplication).Assembly;
            yield return typeof(CreateNewUserCommand).Assembly;
        }
    }
}