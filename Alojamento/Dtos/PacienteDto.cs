using System;

namespace Alojamento.Dtos
{
        public record PacienteDto
    {
        public Guid Id { get; init; }
        public string Nome { get; init; }
        public string NomeProp { get; init; }
        public string Telefone { get; init; }
        public string Endereco { get; init; }
        public string Estado { get; init; }
        public string Motivo { get; init; }
        public string Foto { get; init; }
        public DateTimeOffset Data { get; init; }
    }
}