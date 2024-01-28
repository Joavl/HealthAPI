using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PacientesController : ControllerBase
{
    private readonly PacienteService _pacienteService;

    public PacientesController(PacienteService pacienteService)
    {
        _pacienteService = pacienteService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Paciente>>> GetPacientes()
    {
        var pacientes = await _pacienteService.ObterTodosPacientes();
        return Ok(pacientes);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int id)
    {
        var paciente = await _pacienteService.ObterPacientePorId(id);

        if (paciente == null)
        {
            return NotFound("Paciente não encontrado");
        }

        return Ok(paciente);
    }

    [HttpPost]
    public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
    {
        await _pacienteService.CriarPaciente(paciente);
        return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutPaciente(int id, Paciente paciente)
    {
        if (id != paciente.Id)
        {
            return BadRequest("Ids não correspondem");
        }

        var pacienteExistente = await _pacienteService.ObterPacientePorId(id);
        if (pacienteExistente == null)
        {
            return NotFound("Paciente não encontrado");
        }

        await _pacienteService.AtualizarPaciente(paciente);
        return Ok("Paciente atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePaciente(int id)
    {
        var paciente = await _pacienteService.ObterPacientePorId(id);
        if (paciente == null)
        {
            return NotFound("Paciente não encontrado");
        }

        await _pacienteService.ExcluirPaciente(id);
        return Ok("Paciente excluído com sucesso");
    }
}
