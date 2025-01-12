using FornecedoresApp.ApplicationModels.Entities;
using FornecedoresApp.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FornecedoresAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController(IFornecedoresAppService fornecedorAppService) : Controller
    {
        private readonly IFornecedoresAppService _fornecedorAppService = fornecedorAppService;

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var fornecedores = await _fornecedorAppService.GetAllAsync();
                return Ok(fornecedores);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var fornecedor = await _fornecedorAppService.GetByIdAsync(id);
                return Ok(fornecedor);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(FornecedoresRequest fornecedor)
        {
            try
            {
                await _fornecedorAppService.AddAsync(fornecedor);
                return Ok(fornecedor);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] FornecedoresRequest fornecedor, int id)
        {
            try
            {
                _fornecedorAppService.Update(fornecedor, id);
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _fornecedorAppService.Delete(id);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
