using MsCore.Domain.Entities.Base;

namespace MsCore.Domain.Entities
{
    public class Zona : EntityBase<Guid>
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }        
    }
}
