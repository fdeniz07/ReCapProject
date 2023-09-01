using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //Bu interface’in amaci bundan sonra projemizin calismasina etki eden servislerin, projeden bagimsiz olarak eklenip,calistirilmasini saglayan servisleri çözümlemek için imza niteliğinde olusturulmaktadir.
    public interface ICoreModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
