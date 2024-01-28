using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Medico
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nome { get; set; }

    [Required]
    [MaxLength(100)]
    public string Especialidade { get; set; }

    [Required]
    [MaxLength(20)]
    public string CRM { get; set; }

    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public ICollection<Agendamento> Agendamentos { get; set; }
}
