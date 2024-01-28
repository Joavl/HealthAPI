using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Paciente
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Nome { get; set; }

    [Required]
    public DateTime DataNascimento { get; set; }

    [Required]
    [MaxLength(10)]
    public string Genero { get; set; }

    [Required]
    public string Endereco { get; set; }

    [Required]
    [MaxLength(20)]
    public string Telefone { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string InformacoesSaude { get; set; }

    public ICollection<Agendamento> Agendamentos { get; set; }
}
