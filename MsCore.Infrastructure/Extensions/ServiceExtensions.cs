using Microsoft.Extensions.DependencyInjection;
using MsCore.Domain.Interfaces;
using MsCore.Domain.Services;

namespace MsCore.Infrastructure.Extensions
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
