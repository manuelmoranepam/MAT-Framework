using Autofac;
using ConfigurationClient.Interfaces;

namespace FacadeClient.Interfaces
{
	public interface IFacadeClient
	{
		IContainer GetInstanceOf();
		IConfigurationClient ResolveConfigurationClient(string configFilePath, bool isOptional, bool reloadOnChange);
	}
}