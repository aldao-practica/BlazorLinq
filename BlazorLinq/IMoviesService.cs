using BlazorLinq.Dtos;
using Microsoft.AspNetCore.Mvc;

public interface IMoviesService
{
    Task<List<Cliente>> GetAllCustomersAsync();
    Task<Cliente?> GetCustomerByIdAsync(int id);
    //Task<Cliente> CreateCustomerAsync(ClienteDto clienteDto);
}