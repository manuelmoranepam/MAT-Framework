using Autofac;
using ConfigurationClient.Interfaces;
using JsonResponseClient.Interfaces;

namespace WebDriverClient.Classes
{
	public class FacadeClient
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

		public IJsonResponseClient ResolveJsonResponseClient()
		{
			var jsonResponseClient = _container.Resolve<IJsonResponseClient>();

			return jsonResponseClient;
		}
	}
}