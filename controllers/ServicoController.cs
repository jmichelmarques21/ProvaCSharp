using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaCSharp.Data;
using ProvaCSharp.Models;
using System;
using System.Threading.Tasks;

namespace ProvaCSharp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicosController(AppDbContext context)
        {
            _context = context;
        }

        // Rota para criar um novo serviço
        [HttpPost]
        public async Task<IActionResult> CriarServico([FromBody] Servico novoServico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _context.Servicos.Add(novoServico);
                await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Serviço criado com sucesso", servico = novoServico });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao criar o serviço: {ex.Message}");
            }
        }
    }
}