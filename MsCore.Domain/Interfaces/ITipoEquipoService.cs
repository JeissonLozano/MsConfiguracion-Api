using MsCore.Domain.Entities;

namespace MsCore.Domain.Interfaces
{
    public interface ITipoEquipoService
    {
        Task<IEnumerable<TipoEquipo>> GetAllTipoEquiposAsync();
        Task<TipoEquipo> GetTipoEquipoAsync(Guid id);
        Task<TipoEquipo> RegisterTipoEquipoAsync(TipoEquipo tipoEquipo);
        Task UpdateTipoEquipoAsync(TipoEquipo tipoEquipo);
        Task DeleteTipoEquipoAsync(Guid id);
    }
}
