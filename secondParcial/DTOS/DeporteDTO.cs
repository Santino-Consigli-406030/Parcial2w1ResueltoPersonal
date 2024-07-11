namespace secondParcial.DTOS
{
    public class DeporteDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
    }
}
