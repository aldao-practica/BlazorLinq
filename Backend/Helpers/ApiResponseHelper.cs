using Microsoft.AspNetCore.Mvc;

namespace Backend.Helpers
{
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
}
