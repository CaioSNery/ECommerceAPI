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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos = await _produtoService.ListarProdutosAsync();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarProdutoById(int id)
        {
            var produto = await _produtoService.BuscarProdutoByIdAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduto([FromBody] ProdutoCreateDTO produtoCreateDTO)
        {
            if (produtoCreateDTO == null)
            {
                return BadRequest("Produto data is null.");
            }
            var produto = await _produtoService.CriarProdutoAsync(produtoCreateDTO);
            return CreatedAtAction(nameof(BuscarProdutoById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(int id, [FromBody] ProdutoCreateDTO produtoUpdateDTO)
        {
            if (produtoUpdateDTO == null)
            {
                return BadRequest("Produto data is null.");
            }
            var updated = await _produtoService.AtualizarProdutoAsync(id, produtoUpdateDTO);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var deleted = await _produtoService.DeletarProdutoAsync(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        
        
    }
}