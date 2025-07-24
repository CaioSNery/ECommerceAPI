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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias = await _categoriaService.ListarCategoriasAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCategoriaById(int id)
        {
            var categoria = await _categoriaService.BuscarCategoriaByIdAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] CategoriaCreateDTO categoriaCreateDTO)
        {
            if (categoriaCreateDTO == null)
            {
                return BadRequest("Categoria data is null.");
            }
            var categoria = await _categoriaService.CriarCategoriaAsync(categoriaCreateDTO);
            return CreatedAtAction(nameof(BuscarCategoriaById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, [FromBody] CategoriaCreateDTO categoriaUpdateDTO)
        {
            if (categoriaUpdateDTO == null)
            {
                return BadRequest("Categoria data is null.");
            }
            var updated = await _categoriaService.AtualizarCategoriaAsync(id, categoriaUpdateDTO);
            if (!updated)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var deleted = await _categoriaService.DeletarCategoriaAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
        
    }
}