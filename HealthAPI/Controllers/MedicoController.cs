using Microsoft.AspNetCore.Mvc;
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
        var medicos = await _medicoService.ObterTodosMedicos();
        return Ok(medicos);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Medico>> GetMedico(int id)
    {
        var medico = await _medicoService.ObterMedicoPorId(id);

        if (medico == null)
        {
            return NotFound("Médico não encontrado");
        }

        return Ok(medico);
    }

    [HttpPost]
    public async Task<ActionResult<Medico>> PostMedico(Medico medico)
    {
        await _medicoService.CriarMedico(medico);
        return CreatedAtAction(nameof(GetMedico), new { id = medico.Id }, medico);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> PutMedico(int id, Medico medico)
    {
        if (id != medico.Id)
        {
            return BadRequest("Ids não correspondem");
        }

        var medicoExistente = await _medicoService.ObterMedicoPorId(id);
        if (medicoExistente == null)
        {
            return NotFound("Médico não encontrado");
        }

        await _medicoService.AtualizarMedico(medico);
        return Ok("Médico atualizado com sucesso");
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMedico(int id)
    {
        var medico = await _medicoService.ObterMedicoPorId(id);
        if (medico == null)
        {
            return NotFound("Médico não encontrado");
        }

        await _medicoService.ExcluirMedico(id);
        return Ok("Médico excluído com sucesso");
    }
}


