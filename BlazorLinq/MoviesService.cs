public class MoviesService : IMoviesService
{
    private readonly HttpClient _http;

    public MoviesService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Cliente>> GetAllCustomersAsync()
    {
        return await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");
    }
}
