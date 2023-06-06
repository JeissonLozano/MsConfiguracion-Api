using Microsoft.Extensions.DependencyInjection;
using MsCore.Domain.Interfaces;
using MsCore.Infrastructure.Repositories;

namespace MsCore.Infrastructure.Extensions
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
