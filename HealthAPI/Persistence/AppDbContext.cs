using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Paciente> Pacientes { get; set; }
    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agendamento>()
            .HasOne(a => a.Medico)
            .WithMany(m => m.Agendamentos)
            .HasForeignKey(a => a.MedicoId);

        modelBuilder.Entity<Agendamento>()
            .HasOne(a => a.Paciente)
            .WithMany(p => p.Agendamentos)
            .HasForeignKey(a => a.PacienteId);
    }
}
