using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class MedicoService
{
    private readonly AppDbContext _dbContext;

    public MedicoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Create
    public async Task CriarMedico(Medico medico)
    {
        _dbContext.Medicos.Add(medico);
        await _dbContext.SaveChangesAsync();
    }

    // Read
    public async Task<Medico> ObterMedicoPorId(int medicoId)
    {
        return await _dbContext.Medicos.FindAsync(medicoId);
    }

    public async Task<List<Medico>> ObterTodosMedicos()
    {
        return await _dbContext.Medicos.ToListAsync();
    }

    // Update
    public async Task AtualizarMedico(Medico medico)
    {
        try
        {
            var existingMedico = await _dbContext.Medicos.FindAsync(medico.Id);

            if (existingMedico == null)
            {
                throw new InvalidOperationException("Médico não encontrado");
            }

            _dbContext.Entry(existingMedico).CurrentValues.SetValues(medico);

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar Médico: {ex.Message}");
            throw;
        }
    }




    // Delete
    public async Task ExcluirMedico(int medicoId)
    {
        var medico = await _dbContext.Medicos.FindAsync(medicoId);
        if (medico != null)
        {
            _dbContext.Medicos.Remove(medico);
            await _dbContext.SaveChangesAsync();
        }
    }
}
