using Microsoft.Extensions.DependencyInjection;
using MsConfiguracion.Domain.Interfaces;
using MsConfiguracion.Infrastructure.Repositories;

namespace MsConfiguracion.Infrastructure.Extensions
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc)
        {
            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            return svc;
        }
    }
}
