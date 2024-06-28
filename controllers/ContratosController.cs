using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class ContratosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContratosController(AppDbContext context)
        {
            _context = context;
        }

        // registrar novo contrato
        [HttpPost]
        public async Task<IActionResult> RegistrarContrato([FromBody] Contrato novoContrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Verificar se o cliente e o serviço existem
                var clienteExistente = await _context.Clientes.FindAsync(novoContrato.ClienteId);
                if (clienteExistente == null)
                {
                    return BadRequest("Cliente não encontrado.");
                }

                var servicoExistente = await _context.Servicos.FindAsync(novoContrato.ServicoId);
                if (servicoExistente == null)
                {
                    return BadRequest("Serviço não encontrado.");
                }

                // Adicionar contrato ao contexto e salvar no banco de dados
                _context.Contratos.Add(novoContrato);
                await _context.SaveChangesAsync();

                return Ok(new { mensagem = "Contrato registrado com sucesso", contrato = novoContrato });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno ao registrar o contrato: {ex.Message}");
            }
        }
    }
}