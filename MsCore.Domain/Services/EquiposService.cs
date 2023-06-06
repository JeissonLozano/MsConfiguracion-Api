using MsCore.Domain.Entities;
using MsCore.Domain.Interfaces;

namespace MsCore.Domain.Services
{
    public class EquiposService : IEquiposService
    {
        private readonly IGenericRepository<Equipo> genericRepository;
        private readonly ITipoEquipoService tipoEquipoService;

        public EquiposService(IGenericRepository<Equipo> genericRepository, ITipoEquipoService tipoEquipoService)
        {
            this.genericRepository = genericRepository;
            this.tipoEquipoService = tipoEquipoService;
        }

        public async Task<IEnumerable<Equipo>> GetAllEquipossAsync()
        {
            return await genericRepository.GetAsync(includeStringProperties: "TipoEquipo");
        }

        public async Task<Equipo> GetEquiposAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            return await genericRepository.GetByIdAsync(id);
        }

        public async Task<Equipo> RegisterEquiposAsync(Equipo Equipos)
        {
            if (Equipos == null)
            {
                throw new ArgumentNullException(nameof(Equipos));
            }

            return await genericRepository.AddAsync(Equipos);
        }

        public async Task UpdateEquiposAsync(Equipo Equipos)
        {
            if (Equipos == null)
            {
                throw new ArgumentNullException(nameof(Equipos));
            }
            await genericRepository.UpdateAsync(Equipos);
        }

        public async Task DeleteEquiposAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var Equipos = await genericRepository.GetByIdAsync(id);

            await genericRepository.DeleteAsync(Equipos);
        }
    }
}
