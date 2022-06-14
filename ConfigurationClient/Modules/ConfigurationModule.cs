using Autofac;
using ConfigurationClient.Classes;
using ConfigurationClient.Interfaces;

namespace ConfigurationClient.Modules
{
	public class ConfigurationModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register((context, parameter) => new ConfigurationReader(
					parameter.Named<string>("filePath"),
					parameter.Named<string>("fileName"),
					parameter.Named<bool>("isOptional"),
					parameter.Named<bool>("reloadOnChange")))
				.As<IConfigurationClient>();
		}
	}
}