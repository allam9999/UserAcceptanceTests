using Bindings.Context;
using BoDi;
using TechTalk.SpecFlow;

namespace Bindings
{
    [Binding]
    public class GlobalBinding
    {
        private readonly IObjectContainer _objectContainer;

        public GlobalBinding(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;

        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _objectContainer.RegisterInstanceAs<IContextProperties>(new ContextProperties());
        }
    }
}