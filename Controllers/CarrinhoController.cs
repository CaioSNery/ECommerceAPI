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
    public class CarrinhoController : ControllerBase
    {
        private readonly ICarrinhoService _carrinhoService;

        public CarrinhoController(ICarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCarrinhos()
        {
            var carrinhos = await _carrinhoService.ListarCarrinhosAsync();
            return Ok(carrinhos);
        }

        [HttpPost]
        public async Task<IActionResult> CriarCarrinho([FromBody] CarrinhoDTO carrinhoDTO)
        {
            if (carrinhoDTO == null)
            {
                return BadRequest();
            }
            var carrinho = await _carrinhoService.CriarCarrinhoAsync(carrinhoDTO);
            return CreatedAtAction(nameof(ListarCarrinhos), new { id = carrinho.ProdutoId }, carrinho);
        }

        
    }
}