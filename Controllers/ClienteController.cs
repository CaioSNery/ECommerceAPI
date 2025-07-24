using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceAPI.Dtos;
using ECommerceAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarClientes()
        {
            var clientes = await _clienteService.ListarClientesAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarClienteById(int id)
        {
            var cliente = await _clienteService.BuscarClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCliente([FromBody] ClienteCreateDTO clienteCreateDTO)
        {
            if (clienteCreateDTO == null)
            {
                return BadRequest();
            }
            var cliente = await _clienteService.CriarClienteAsync(clienteCreateDTO);
            return CreatedAtAction(nameof(BuscarClienteById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteCreateDTO clienteUpdateDTO)
        {
            if (clienteUpdateDTO == null)
            {
                return BadRequest();
            }
            var cliente = await _clienteService.UpdateClienteAsync(id, clienteUpdateDTO);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var result = await _clienteService.DeleteClienteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        
    }
}