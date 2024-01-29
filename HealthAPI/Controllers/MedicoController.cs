using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class MedicosController : ControllerBase
{
    private readonly MedicoService _medicoService;

    public MedicosController(MedicoService medicoService)
    {
        _medicoService = medicoService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Medico>>> GetMedicos()
    {
        try
        {
            var medicos = await _medicoService.ObterTodosMedicos();
            return Ok(medicos);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao obter a lista de médicos", errorDetails = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Medico>> GetMedico(int id)
    {
        try
        {
            var medico = await _medicoService.ObterMedicoPorId(id);

            if (medico == null)
            {
                return NotFound(new { message = "Médico não encontrado", errorCode = 404 });
            }

            return Ok(medico);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao obter o médico", errorDetails = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<Medico>> PostMedico([FromBody] Medico medico)
    {
        try
        {
            await _medicoService.CriarMedico(medico);
            return CreatedAtAction(nameof(GetMedico), new { id = medico.Id }, medico);
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao criar o médico", errorDetails = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutMedico(int id, [FromBody] Medico medico)
    {
        try
        {
            if (id != medico.Id)
            {
                return BadRequest(new { message = "Ids não correspondem", errorCode = 400 });
            }

            var medicoExistente = await _medicoService.ObterMedicoPorId(id);
            if (medicoExistente == null)
            {
                return NotFound(new { message = "Médico não encontrado", errorCode = 404 });
            }

            await _medicoService.AtualizarMedico(medico);
            return Ok(new { message = "Médico atualizado com sucesso" });
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao atualizar o médico", errorDetails = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMedico(int id)
    {
        try
        {
            var medico = await _medicoService.ObterMedicoPorId(id);
            if (medico == null)
            {
                return NotFound(new { message = "Médico não encontrado", errorCode = 404 });
            }

            await _medicoService.ExcluirMedico(id);
            return Ok(new { message = "Médico excluído com sucesso" });
        }
        catch (Exception ex)
        {
            // Logar a exceção e retornar uma resposta de erro apropriada.
            return StatusCode(500, new { message = "Erro interno ao excluir o médico", errorDetails = ex.Message });
        }
    }
}
