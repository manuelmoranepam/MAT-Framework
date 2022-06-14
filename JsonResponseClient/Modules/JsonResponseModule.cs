using Autofac;
using JsonResponseClient.Classes;
using JsonResponseClient.Interfaces;

namespace JsonResponseClient.Modules
{
	public class JsonResponseModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.Register((context) => new JsonResponseSetup()).As<IJsonResponseClient>();
		}
	}
}