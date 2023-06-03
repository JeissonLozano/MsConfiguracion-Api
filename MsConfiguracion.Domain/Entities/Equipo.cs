using MsConfiguracion.Domain.Entities.Base;

namespace MsConfiguracion.Domain.Entities
{
    public class Equipo : EntityBase<Guid>
    {
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public Guid IdTipoEquipo { get; set; }

        public virtual TipoEquipo TipoEquipo { get; set; }
    }

}
