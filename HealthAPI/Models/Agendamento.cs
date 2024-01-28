public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHoraConsulta { get; set; }
    public string MotivoConsulta { get; set; }

    public int MedicoId { get; set; }
    public Medico Medico { get; set; }

    public int PacienteId { get; set; }
    public Paciente Paciente { get; set; }

    public EstadoConsulta Estado { get; set; }

    public enum EstadoConsulta
    {
        Agendada,
        Concluida,
        Cancelada
    }
}
