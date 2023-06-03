using MsConfiguracion.Domain.Entities;
using MsConfiguracion.Domain.Interfaces;

namespace MsConfiguracion.Domain.Services
{
    public class TipoEquiposService : ITipoEquipoService
    {
        private readonly IGenericRepository<TipoEquipo> genericRepository;

        public TipoEquiposService(IGenericRepository<TipoEquipo> genericRepository)
        {
            this.genericRepository = genericRepository;
        }

        public async Task<IEnumerable<TipoEquipo>> GetAllTipoEquiposAsync()
        {
            return await genericRepository.GetAsync();
        }

        public async Task<TipoEquipo> GetTipoEquipoAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await genericRepository.GetByIdAsync(id);
        }

        public async Task<TipoEquipo> RegisterTipoEquipoAsync(TipoEquipo tipoEquipo)
        {
            if (tipoEquipo == null)
            {
                throw new ArgumentNullException(nameof(tipoEquipo));
            }

            return await genericRepository.AddAsync(tipoEquipo);
        }

        public async Task UpdateTipoEquipoAsync(TipoEquipo tipoEquipo)
        {
            if (tipoEquipo == null)
            {
                throw new ArgumentNullException(nameof(tipoEquipo));
            }
            await genericRepository.UpdateAsync(tipoEquipo);
        }

        public async Task DeleteTipoEquipoAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var tipoEquipo = await genericRepository.GetByIdAsync(id);

            await genericRepository.DeleteAsync(tipoEquipo);
        }
    }
}
