using Microsoft.Extensions.DependencyInjection;
using MsCore.Domain.Interfaces;
using MsCore.Domain.Services;

namespace MsCore.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            svc.AddTransient(typeof(IProductService), typeof(ProductService));
            return svc;
        }
    }
}
