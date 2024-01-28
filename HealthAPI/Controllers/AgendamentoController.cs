using Microsoft.AspNetCore.Mvc;
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
        var agendamentos = await _agendamentoService.ObterTodosAgendamentos();
        return Ok(agendamentos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Agendamento>> GetAgendamento(int id)
    {
        var agendamento = await _agendamentoService.ObterAgendamentoPorId(id);

        if (agendamento == null)
        {
            return NotFound();
        }

        return Ok(agendamento);
    }

    [HttpPost]
    public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
    {
        await _agendamentoService.CriarAgendamento(agendamento);
        return CreatedAtAction(nameof(GetAgendamento), new { id = agendamento.Id }, agendamento);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutAgendamento(int id, Agendamento agendamento)
    {
        if (id != agendamento.Id)
        {
            return BadRequest("Ids não correspondem");
        }

        var agendamentoExistente = await _agendamentoService.ObterAgendamentoPorId(id);
        if (agendamentoExistente == null)
        {
            return NotFound("Agendamento não encontrado");
        }

        await _agendamentoService.AtualizarAgendamento(agendamento);
        return Ok("Agendamento atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAgendamento(int id)
    {
        var agendamento = await _agendamentoService.ObterAgendamentoPorId(id);
        if (agendamento == null)
        {
            return NotFound("Agendamento não encontrado");
        }

        await _agendamentoService.ExcluirAgendamento(id);
        return Ok("Agendamento excluído com sucesso");
    }
}
