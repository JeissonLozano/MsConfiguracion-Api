using MsConfiguracion.Domain.Entities.Base;

namespace MsConfiguracion.Domain.Entities
{
    public class TipoEquipo : EntityBase<Guid>
    {
        public string NombreTipoEquipo { get; set; }
        public string Descripcion { get; set; }

        public virtual Equipo Equipo { get; set; }
    }
}
