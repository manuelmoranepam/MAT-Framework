using Autofac;
using WebDriverClient.Classes;
using WebDriverClient.Interfaces;
using WebDriverClient.Models;

namespace WebDriverClient.Modules
{
	public class WebDriverModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register((context, parameter) => new WebDriverSetup(
					parameter.Named<IContainer>("container"),
					parameter.Named<IConfigurationFileInformation>("configurationFileInformation")))
				.As<IWebDriverClient>();

			builder.Register((context, parameter) => new ConfigurationFileInformation(
					parameter.Named<string>("filePath"),
					parameter.Named<string>("fileName"),
					parameter.Named<bool>("isOptional"),
					parameter.Named<bool>("reloadOnChange")))
				.As<IConfigurationFileInformation>();

			builder.Register((context, parameter) => new DriverConfiguration()).As<IDriverConfiguration>();
		}
	}
}
