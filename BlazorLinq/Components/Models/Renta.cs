namespace BlazorLinq.Components.Models
{
    public class Renta
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int VideocassetteId { get; set; }
        public Videocassette Videocassette { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime? FechaDevolucion { get; set; }
    }

}
