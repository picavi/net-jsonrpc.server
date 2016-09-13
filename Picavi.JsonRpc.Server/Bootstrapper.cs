namespace Picavi.JsonRpc.Server
{
    using DI;
    using Nancy;
    using Nancy.Bootstrapper;
    using Nancy.TinyIoc;
    using Picavi.JsonRpc.Server.Rpc;
    using SimpleInjector;
    using SimpleInjector.Extensions.ExecutionContextScoping;

    public class Bootstrapper : DefaultNancyBootstrapper
    {
        // protected Methods

        protected override void ApplicationStartup(TinyIoCContainer nancy, IPipelines pipelines)
        {
            // Create Simple Injector container
            Container container = new Container();
            container.Options.DefaultScopedLifestyle = new ExecutionContextScopeLifestyle();

            var requestBroker = new RequestBroker();
            RegisterMethods(requestBroker);

            // Register application components here, e.g.:
            container.RegisterSingleton<RequestBroker>(requestBroker);

            // Register Nancy modules.
            foreach (var nancyModule in this.Modules) container.Register(nancyModule.ModuleType);

            // Cross-wire Nancy abstractions that application components require (if any). e.g.:
            //container.Register(nancy.Resolve<IModelValidator>);

            // Check the container.
            container.Verify();

            // Hook up Simple Injector in the Nancy pipeline.
            nancy.Register(typeof(INancyModuleCatalog), new SimpleInjectorModuleCatalog(container));
            nancy.Register(typeof(INancyContextFactory), new SimpleInjectorScopedContextFactory(
                container, nancy.Resolve<INancyContextFactory>()));
        }

        // private Methods

        private void RegisterMethods(RequestBroker requestBroker)
        { 
            var systemAuth = new SystemAuth();
            requestBroker.Add("system.login", systemAuth.Login);

            var orderPicking = new OrderPicking();
            requestBroker.Add("orderPicking.getPickList", orderPicking.GetPickList);
        }
    }
}
