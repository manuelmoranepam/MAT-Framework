using Autofac;
using ConfigurationClient.Interfaces;
using ConfigurationClient.Modules;
using FacadeClient.Interfaces;

namespace FacadeClient.Classes
{
	public class ContainerSetup : IFacadeClient
	{
		private readonly ContainerBuilder _containerBuilder;
		private readonly IContainer _container;

		public ContainerSetup()
		{
			_containerBuilder = new ContainerBuilder();

			_containerBuilder.RegisterModule<ConfigurationModule>();

			_container = _containerBuilder.Build();
		}

		public IContainer GetInstanceOf()
		{
			return _container;
		}

		public IConfigurationClient ResolveConfigurationClient(string configFilePath, bool isOptional, bool reloadOnChange)
		{
			var configuration = _container.Resolve<IConfigurationClient>(
				new NamedParameter("path", configFilePath),
				new NamedParameter("isOptional", isOptional),
				new NamedParameter("reloadOnChange", reloadOnChange));

			return configuration;
		}
	}
}