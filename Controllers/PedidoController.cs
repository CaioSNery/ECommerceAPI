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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarPedidos()
        {
            var pedidos = await _pedidoService.ListarPedidosAsync();
            return Ok(pedidos);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarPedidoById(int id)
        {
            var pedido = await _pedidoService.BuscarPedidoByIdAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return Ok(pedido);
        }

        [HttpPost]
        public async Task<IActionResult> CriarPedido([FromBody] PedidoCreateDTO pedidoDTO)
        {
            if (pedidoDTO == null)
            {
                return BadRequest();
            }
            var pedido = await _pedidoService.CriarPedidoAsync(pedidoDTO);
            return CreatedAtAction(nameof(BuscarPedidoById), new { id = pedido.Id}, pedido);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedido(int id, [FromBody] PedidoCreateDTO pedidoUpdateDTO)
        {
            if (pedidoUpdateDTO == null)
            {
                return BadRequest();
            }
            var updated = await _pedidoService.UpdatePedidoAsync(id, pedidoUpdateDTO);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var deleted = await _pedidoService.DeletePedidoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        

        
    }
}