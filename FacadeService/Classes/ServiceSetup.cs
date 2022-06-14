using Autofac;
using ConfigurationClient.Modules;
using FacadeService.Interfaces;
using JsonResponseClient.Modules;
using WebDriverClient.Modules;

namespace FacadeService.Classes
{
	public class ServiceSetup : IFacadeService
	{
		private readonly ContainerBuilder _containerBuilder;
		private readonly IContainer _container;

		public ServiceSetup()
		{
			_containerBuilder = new ContainerBuilder();

			_containerBuilder.RegisterModule<ConfigurationModule>();
			_containerBuilder.RegisterModule<WebDriverModule>();
			_containerBuilder.RegisterModule<JsonResponseModule>();

			_container = _containerBuilder.Build();
		}

		public IContainer GetInstanceOf()
		{
			return _container;
		}
	}
}