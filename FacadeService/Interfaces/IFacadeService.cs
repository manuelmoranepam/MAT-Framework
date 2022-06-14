using Autofac;

namespace FacadeService.Interfaces
{
	public interface IFacadeService
	{
		IContainer GetInstanceOf();
	}
}