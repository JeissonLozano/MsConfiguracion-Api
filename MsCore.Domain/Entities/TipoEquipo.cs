using MsCore.Domain.Entities.Base;

namespace MsCore.Domain.Entities
{
    public class TipoEquipo : EntityBase<Guid>
    {
        public string NombreTipoEquipo { get; set; }
        public string Descripcion { get; set; }

        public virtual IEnumerable<Equipo> Equipos { get; set; }
    }
}
