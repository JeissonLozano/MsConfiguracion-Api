using MsConfiguracion.Domain.Entities;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Domain.Services
{
    public class ZonaService : IZonaService
    {
        private readonly IGenericRepository<Zona> genericRepository;

        public ZonaService(IGenericRepository<Zona> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Zona>> GetAllZonasAsync()
        {
            return await genericRepository.GetAsync();
        }

        public async Task<Zona> GetZonaAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));

            }
            return await genericRepository.GetByIdAsync(id);
        }

        public async Task<Zona> RegisterZonaAsync(Zona Zona)
        {
            if (Zona == null)
            {
                throw new ArgumentNullException(nameof(Zona));
            }
            return await genericRepository.AddAsync(Zona);
        }

        public async Task UpdateZonaAsync(Zona Zona)
        {
            if (Zona == null)
            {
                throw new ArgumentNullException(nameof(Zona));
            }
            await genericRepository.UpdateAsync(Zona);
        }

        public async Task DeleteZonaAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }
            var Zona = await genericRepository.GetByIdAsync(id);
            await genericRepository.DeleteAsync(Zona);
        }
    }
}
