using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Backend.Helpers;

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

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClientesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<Cliente>>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return ApiResultHelper.Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<Cliente>>> GetClienteById(int id)
        {
            //var cliente = await _context.Clientes.FindAsync(id);

            //if (cliente == null)
            //    return NotFound();

            //return Ok(cliente);

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return ApiResultHelper.NotFound<Cliente>($"Cliente con ID {id} no encontrado");

            return ApiResultHelper.Ok(cliente);
        }

        //[HttpPost]
        //public async Task<ActionResult<Cliente>> PostCliente([FromBody] ClienteDto clienteDto)
        //{
        //    if (clienteDto == null)
        //        return BadRequest("Datos inválidos");

        //    var cliente = new Cliente
        //    {
        //        Fullname = clienteDto.Fullname,
        //        Email = clienteDto.Email,
        //        Age = clienteDto.Age
        //    };

        //    _context.Clientes.Add(cliente);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        //}
    }
}
