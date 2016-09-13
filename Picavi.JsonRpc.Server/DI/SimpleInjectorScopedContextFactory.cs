namespace Picavi.JsonRpc.Server.DI
{
    using Nancy;
    using SimpleInjector;
    using SimpleInjector.Extensions.ExecutionContextScoping;

    public sealed class SimpleInjectorScopedContextFactory : INancyContextFactory
    {
        // private Fields

        private readonly Container container;

        private readonly INancyContextFactory defaultFactory;

        // Constructors

        public SimpleInjectorScopedContextFactory(Container container, INancyContextFactory @default)
        {
            this.container = container;
            this.defaultFactory = @default;
        }

        // public Methods

        public NancyContext Create(Request request)
        {
            var context = this.defaultFactory.Create(request);
            context.Items.Add("SimpleInjector.Scope", container.BeginExecutionContextScope());
            return context;
        }
    }
}
