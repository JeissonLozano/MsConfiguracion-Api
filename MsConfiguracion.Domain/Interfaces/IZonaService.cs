using MsConfiguracion.Domain.Entities;

namespace MsConfiguracion.Domain.Interfaces
{
    public interface IZonaService
    {
        Task<IEnumerable<Zona>> GetAllZonasAsync();
        Task<Zona> GetZonaAsync(Guid id);
        Task<Zona> RegisterZonaAsync(Zona Zona);
        Task UpdateZonaAsync(Zona Zona);
        Task DeleteZonaAsync(Guid id);

    }
}
