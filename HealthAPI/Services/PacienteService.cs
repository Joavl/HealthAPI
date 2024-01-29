using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PacienteService
{
    private readonly AppDbContext _dbContext;

    public PacienteService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CriarPaciente(Paciente paciente)
    {
        _dbContext.Pacientes.Add(paciente);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Paciente> ObterPacientePorId(int pacienteId)
    {
        return await _dbContext.Pacientes.FindAsync(pacienteId);
    }

    public async Task<List<Paciente>> ObterTodosPacientes()
    {
        return await _dbContext.Pacientes.ToListAsync();
    }

    public async Task AtualizarPaciente(Paciente paciente)
    {
        var existingPaciente = await _dbContext.Pacientes.FindAsync(paciente.Id);

        if (existingPaciente == null)
        {
            throw new InvalidOperationException("Paciente não encontrado");
        }

        _dbContext.Entry(existingPaciente).CurrentValues.SetValues(paciente);

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new InvalidOperationException("Não foi possível atualizar os dados");
        }
    }

    public async Task ExcluirPaciente(int pacienteId)
    {
        var paciente = await _dbContext.Pacientes.FindAsync(pacienteId);

        if (paciente != null)
        {
            _dbContext.Pacientes.Remove(paciente);
            await _dbContext.SaveChangesAsync();
        }
    }
}
