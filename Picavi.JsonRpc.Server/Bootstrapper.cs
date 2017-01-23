// <copyright file="Bootstrapper.cs" company="Picavi">
//     Company copyright tag.
// </copyright>
namespace Picavi.JsonRpc.Server
{
    using DI;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.Responses.Negotiation;
    using Nancy.TinyIoc;
    using Picavi.JsonRpc.Server.Framework.Exceptions.Web;
    using Picavi.JsonRpc.Server.Rpc;
    using SimpleInjector;
    using SimpleInjector.Extensions.ExecutionContextScoping;

    /// <summary>
    /// class Bootstrap the application
    /// </summary>
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        /// <summary>
        /// Gets InternalConfiguration
        /// </summary>
        protected override NancyInternalConfiguration InternalConfiguration
        {
            get
            {
                return NancyInternalConfiguration.WithOverrides(config =>
                {
                    config.StatusCodeHandlers = new[] { typeof(StatusCodeHandler404), typeof(StatusCodeHandler500) };
                    config.ResponseProcessors = new[] { typeof(JsonProcessor), typeof(XmlProcessor) };

                });
            }
        }

        //// protected Methods

        /// <summary>
        /// method ApplicationStartup
        /// </summary>
        /// <param name="nancy">nancy parameter</param>
        /// <param name="pipelines">pipelines parameter</param>
        protected override void ApplicationStartup(TinyIoCContainer nancy, IPipelines pipelines)
        {
            // Create Simple Injector container
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var requestBroker = new RequestBroker();
            this.RegisterMethods(requestBroker);

            // Register application components here, e.g.:
            container.RegisterSingleton<RequestBroker>(requestBroker);

            // Register Nancy modules.
            foreach (var nancyModule in this.Modules)
            {
                container.Register(nancyModule.ModuleType);
            }

            // Cross-wire Nancy abstractions that application components require (if any). e.g.:
            // container.Register(nancy.Resolve<IModelValidator>);

            // Check the container.
            container.Verify();

            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof(INancyModuleCatalog), new SimpleInjectorModuleCatalog(container));

            nancy.Register(typeof(INancyContextFactory), new SimpleInjectorScopedContextFactory(container, nancy.Resolve<INancyContextFactory>()));
        }

        // protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        // {
        // CustomErrorHandler.Enable(pipelines, container.Resolve<IResponseNegotiator>());
        // }
       
        /// <summary>
        /// private method RegisterMethods
        /// </summary>
        /// <param name="requestBroker">Request broker</param>
        private void RegisterMethods(RequestBroker requestBroker)
        {
            var systemAuth = new SystemAuth();
            requestBroker.Add("system.login", systemAuth.Login);

            var orderPicking = new OrderPicking();
            requestBroker.Add("orderPicking.getPickList", orderPicking.GetPickList);
        }
    }
}
