namespace Backend.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }
        public ICollection<Videocassette> Videocassetes { get; set; }
    }
}
