using BlazorLinq.Dtos;
using Microsoft.AspNetCore.Mvc;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public string? ErrorMessage { get; set; }
    public Dictionary<string, string>? ValidationErrors { get; set; }
    public static ApiResponse<T> SuccessResponse(T data) => new() { Success = true, Data = data };
    public static ApiResponse<T> ErrorResponse(string message) => new() { Success = false, ErrorMessage = message };
    public static ApiResponse<T> ValidationError(Dictionary<string, string> errors) => new() { Success = false, ValidationErrors = errors };
}

public static class ApiResultHelper
{
    public static ActionResult<ApiResponse<T>> Ok<T>(T data)
        => new OkObjectResult(ApiResponse<T>.SuccessResponse(data));

    public static ActionResult<ApiResponse<T>> Created<T>(string location, T data)
    {
        var response = ApiResponse<T>.SuccessResponse(data);
        return new CreatedResult(location, response);
    }

    public static ActionResult<ApiResponse<T>> NotFound<T>(string message)
        => new NotFoundObjectResult(ApiResponse<T>.ErrorResponse(message));

    public static ActionResult<ApiResponse<T>> BadRequest<T>(string message)
        => new BadRequestObjectResult(ApiResponse<T>.ErrorResponse(message));

    public static ActionResult<ApiResponse<T>> Validation<T>(Dictionary<string, string> errors)
        => new BadRequestObjectResult(ApiResponse<T>.ValidationError(errors));
}


public class MoviesService : IMoviesService
{
    private readonly HttpClient _http;

    public MoviesService(HttpClient http)
    {
        _http = http;
    }

    //public async Task<List<Cliente>> GetAllCustomersAsync()
    //{
    //    private result = await _http.GetFromJsonAsync<List<Cliente>>("api/clientes");
    //}

    public async Task<Cliente?> GetCustomerByIdAsync(int id)
    {
        var response = await _http.GetFromJsonAsync<ApiResponse<Cliente>>($"api/clientes/{id}");

        if (response is null || !response.Success)
        {
            // Mostrar error o loguear, según el caso
            Console.WriteLine(response?.ErrorMessage ?? "Error desconocido");
            return null;
        }

        return response.Data;
    }

    //public async Task<Cliente> CreateCustomerAsync(ClienteDto clienteDto)
    //{
    //    var response = await _http.PostAsJsonAsync("api/clientes", clienteDto);

    //    if (response.IsSuccessStatusCode)
    //    {
    //        return await response.Content.ReadFromJsonAsync<Cliente>();
    //    }

    //    // Manejo básico de error: podrías lanzar una excepción o loguear
    //    return null;
    //}
}
