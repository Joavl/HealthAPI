using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class AgendamentosController : ControllerBase
{
    private readonly AgendamentoService _agendamentoService;

    public AgendamentosController(AgendamentoService agendamentoService)
    {
        _agendamentoService = agendamentoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Agendamento>>> GetAgendamentos()
    {
        try
        {
            var agendamentos = await _agendamentoService.ObterTodosAgendamentos();
            return Ok(agendamentos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao obter a lista de agendamentos", errorDetails = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
    {
        try
        {
            var agendamento = await _agendamentoService.ObterAgendamentoPorId(id);

            if (agendamento == null)
            {
                return NotFound(new { message = "Agendamento não encontrado", errorCode = 404 });
            }

            return Ok(agendamento);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao obter o agendamento", errorDetails = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Agendamento>> PostAgendamento([FromBody] Agendamento agendamento)
    {
        try
        {
            await _agendamentoService.CriarAgendamento(agendamento);
            return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.Id }, agendamento);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao criar o agendamento", errorDetails = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutAgendamento(int id, [FromBody] Agendamento agendamento)
    {
        try
        {
            if (id != agendamento.Id)
            {
                return BadRequest(new { message = "Ids não correspondem", errorCode = 400 });
            }

            var agendamentoExistente = await _agendamentoService.ObterAgendamentoPorId(id);
            if (agendamentoExistente == null)
            {
                return NotFound(new { message = "Agendamento não encontrado", errorCode = 404 });
            }

            await _agendamentoService.AtualizarAgendamento(agendamento);
            return Ok(new { message = "Agendamento atualizado com sucesso" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao atualizar o agendamento", errorDetails = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAgendamento(int id)
    {
        try
        {
            var agendamento = await _agendamentoService.ObterAgendamentoPorId(id);
            if (agendamento == null)
            {
                return NotFound(new { message = "Agendamento não encontrado", errorCode = 404 });
            }

            await _agendamentoService.ExcluirAgendamento(id);
            return Ok(new { message = "Agendamento excluído com sucesso" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Erro interno ao excluir o agendamento", errorDetails = ex.Message });
        }
    }
}
