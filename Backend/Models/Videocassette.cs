namespace Backend.Models
{
    public class Videocassette
    {
        public int Id { get; set; }
        public string CodigoInventario { get; set; }
        public string Estado { get; set; }
        public int PeliculaId { get; set; }
        public Pelicula Pelicula { get; set; }
        public ICollection<Renta> Rentas { get; set; }
    }

}
