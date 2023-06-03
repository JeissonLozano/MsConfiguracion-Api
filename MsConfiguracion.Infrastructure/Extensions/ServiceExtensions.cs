using Microsoft.Extensions.DependencyInjection;
using MsConfiguracion.Domain.Interfaces;
using MsConfiguracion.Domain.Services;

namespace MsConfiguracion.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            svc.AddTransient(typeof(IEquiposService), typeof(EquiposService));
            svc.AddTransient(typeof(ITipoEquipoService), typeof(TipoEquiposService));
            svc.AddTransient(typeof(IZonaService), typeof(ZonaService));
            return svc;
        }
    }
}
