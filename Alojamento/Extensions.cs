using Alojamento.Dtos;
using Alojamento.Models;

namespace Alojamento
{
    public static class Extensions
    {
        public static PacienteDto AsDto(this Paciente paciente)
        {
            return new PacienteDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                NomeProp = paciente.NomeProp,
                Telefone = paciente.Telefone,
                Endereco = paciente.Endereco,
                Estado = paciente.Estado,
                Motivo = paciente.Motivo,
                Data = paciente.Data
            };
        }
    }
}