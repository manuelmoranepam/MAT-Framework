using Autofac;
using ConfigurationClient.Interfaces;
using JsonResponseClient.Interfaces;
using WebDriverClient.Interfaces;

namespace OrangeHRMTestingSuite.Classes
{
	internal class FacadeClient
	{
		private readonly IContainer _container;

		public FacadeClient(IContainer container)
		{
			_container = container;
		}

		public IConfigurationClient ResolveConfigurationClient(string filePath, string fileName, bool isOptional, bool reloadOnChange)
		{
			var configuration = _container.Resolve<IConfigurationClient>(
				new NamedParameter("filePath", filePath),
				new NamedParameter("fileName", fileName),
				new NamedParameter("isOptional", isOptional),
				new NamedParameter("reloadOnChange", reloadOnChange));

			return configuration;
		}

		public IConfigurationFileInformation ResolveConfigurationFileInformationClient(string filePath, string fileName, bool isOptional, bool reloadOnChange)
		{
			var fileInformation = _container.Resolve<IConfigurationFileInformation>(
				new NamedParameter("filePath", filePath),
				new NamedParameter("fileName", fileName),
				new NamedParameter("isOptional", isOptional),
				new NamedParameter("reloadOnChange", reloadOnChange));

			return fileInformation;
		}

		public IWebDriverClient ResolveWebDriverClient(IContainer container, IConfigurationFileInformation configurationFileInformation)
		{
			var webDriverClient = _container.Resolve<IWebDriverClient>(
				new NamedParameter("container", container),
				new NamedParameter("configurationFileInformation", configurationFileInformation));

			return webDriverClient;
		}

		public IDriverConfiguration ResolveDriverConfigurationModel()
		{
			var driverConfiguration = _container.Resolve<IDriverConfiguration>();

			return driverConfiguration;
		}

		public IJsonResponseClient ResolveJsonResponseClient()
		{
			var jsonResponseClient = _container.Resolve<IJsonResponseClient>();

			return jsonResponseClient;
		}
	}
}
