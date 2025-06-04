namespace Backend.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public required string Fullname { get; set; }
        public required string Email { get; set; }

        public int Age { get; set; }
        //public DateTime FechaRegistro { get; set; }
        //public ICollection<Renta> Rentas { get; set; }
    }
}
