namespace Backend.Dtos
{
    public class ClienteDto
    {
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class ClienteResponseDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
