using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class AgendamentoService
{
    private readonly AppDbContext _dbContext;

    public AgendamentoService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Create
    public async Task CriarAgendamento(Agendamento agendamento)
    {
        var medicoExistente = await _dbContext.Medicos.FindAsync(agendamento.MedicoId);

        if (medicoExistente == null)
        {
            throw new InvalidOperationException("Médico não encontrado");
        }

        _dbContext.Agendamentos.Add(agendamento);
        await _dbContext.SaveChangesAsync();
    }

    // Read
    public async Task<Agendamento> ObterAgendamentoPorId(int agendamentoId)
    {
        return await _dbContext.Agendamentos
            .Include(a => a.Medico)
            .Include(a => a.Paciente)
            .FirstOrDefaultAsync(a => a.Id == agendamentoId);
    }

    public async Task<List<Agendamento>> ObterTodosAgendamentos()
    {
        return await _dbContext.Agendamentos
            .Include(a => a.Medico)
            .Include(a => a.Paciente)
            .ToListAsync();
    }

    // Update
    public async Task AtualizarAgendamento(Agendamento agendamento)
    {
        try
        {
            var existingAgendamento = await _dbContext.Agendamentos
                .Include(a => a.Medico) 
                .FirstOrDefaultAsync(a => a.Id == agendamento.Id);

            if (existingAgendamento == null)
            {
                throw new InvalidOperationException("Agendamento não encontrado");
            }

            _dbContext.Entry(existingAgendamento).State = EntityState.Detached;

            _dbContext.Agendamentos.Update(agendamento);

            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao atualizar Agendamento: {ex.Message}");
            throw;
        }
    }



    // Delete
    public async Task ExcluirAgendamento(int agendamentoId)
    {
        var agendamento = await _dbContext.Agendamentos.FindAsync(agendamentoId);
        if (agendamento != null)
        {
            _dbContext.Agendamentos.Remove(agendamento);
            await _dbContext.SaveChangesAsync();
        }
    }
}
