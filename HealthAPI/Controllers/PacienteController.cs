using Microsoft.AspNetCore.Mvc;
using System;
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
        try
        {
            var pacientes = await _pacienteService.ObterTodosPacientes();
            return Ok(pacientes);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao obter a lista de pacientes", errorDetails = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Paciente>> GetPaciente(int id)
    {
        try
        {
            var paciente = await _pacienteService.ObterPacientePorId(id);

            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado", errorCode = 404 });
            }

            return Ok(paciente);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao obter o paciente", errorDetails = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Paciente>> PostPaciente([FromBody] Paciente paciente)
    {
        try
        {
            await _pacienteService.CriarPaciente(paciente);
            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao criar o paciente", errorDetails = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutPaciente(int id, [FromBody] Paciente paciente)
    {
        try
        {
            if (id != paciente.Id)
            {
                return BadRequest(new { message = "Ids não correspondem", errorCode = 400 });
            }

            var pacienteExistente = await _pacienteService.ObterPacientePorId(id);
            if (pacienteExistente == null)
            {
                return NotFound(new { message = "Paciente não encontrado", errorCode = 404 });
            }

            await _pacienteService.AtualizarPaciente(paciente);
            return Ok(new { message = "Paciente atualizado com sucesso" });
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao atualizar o paciente", errorDetails = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePaciente(int id)
    {
        try
        {
            var paciente = await _pacienteService.ObterPacientePorId(id);
            if (paciente == null)
            {
                return NotFound(new { message = "Paciente não encontrado", errorCode = 404 });
            }

            await _pacienteService.ExcluirPaciente(id);
            return Ok(new { message = "Paciente excluído com sucesso" });
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao excluir o paciente", errorDetails = ex.Message });
        }
    }
}
