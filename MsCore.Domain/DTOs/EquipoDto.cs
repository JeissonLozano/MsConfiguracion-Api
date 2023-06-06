namespace MsCore.Domain.DTOs
{
    public class EquiposDto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
        public Guid IdTipoEquipo { get; set; }
        public string NombreTipoEquipo { get; set; }
    }
}
