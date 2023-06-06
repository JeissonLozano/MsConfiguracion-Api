using MsCore.Domain.Entities;

namespace MsCore.Domain.Interfaces
{
    public interface IEquiposService
    {
        Task<IEnumerable<Equipo>> GetAllEquipossAsync();
        Task<Equipo> GetEquiposAsync(Guid id);
        Task<Equipo> RegisterEquiposAsync(Equipo Equipos);
        Task UpdateEquiposAsync(Equipo Equipos);
        Task DeleteEquiposAsync(Guid id);
    }
}
