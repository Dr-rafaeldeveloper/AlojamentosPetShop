using System.ComponentModel.DataAnnotations;

namespace Alojamento.Dtos
{
    public record UpdatePacienteDto
    {
        [Required]
        public string Nome { get; init; }
        [Required]
        public string NomeProp { get; init; }
        [Required]
        public string Telefone { get; init; }
        [Required]
        public string Endereco { get; init; }
        [Required]
        public string Estado { get; init; }
        [Required]
        public string Motivo { get; init; }
        
        public string Foto { get; init; }
    }
}