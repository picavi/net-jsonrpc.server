namespace Picavi.JsonRpc.Server.DI
{
    using Nancy;
    using SimpleInjector;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class SimpleInjectorModuleCatalog : INancyModuleCatalog
    {
        // private Fields

        private readonly Container container;

        // Constructors

        public SimpleInjectorModuleCatalog(Container container)
        {
            this.container = container;
        }

        // public Methods

        public INancyModule GetModule(Type moduleType, NancyContext context)
        {
            return (INancyModule)this.container.GetInstance(moduleType);
        }

        public IEnumerable<INancyModule> GetAllModules(NancyContext context)
        {
            return from r in this.container.GetCurrentRegistrations()
                   where typeof(INancyModule).IsAssignableFrom(r.ServiceType)
                   select (INancyModule)r.GetInstance();
        }
    }
}
