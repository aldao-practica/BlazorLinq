namespace Backend.Models
{
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
}
