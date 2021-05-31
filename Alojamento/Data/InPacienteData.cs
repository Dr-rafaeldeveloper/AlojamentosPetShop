using System;
using System.Collections.Generic;
using System.Linq;
using Alojamento.Models;

namespace Alojamento.Data
{
    public class InPacienteData : IPacienteData
    {
        private readonly List<Paciente> pacientes = new()
        {
            new Paciente
            {
                Id = Guid.NewGuid(),
                Nome = "Lisa",
                NomeProp = "Rafael",
                Telefone = "33360157",
                Endereco = "Rua Maria 51",
                Estado = "Em tratamento",
                Motivo = "Dor de Barriga",
                Foto = "foto01.png",
                Data = DateTimeOffset.UtcNow
            },
            new Paciente
            {
                Id = Guid.NewGuid(),
                Nome = "Paquita",
                NomeProp = "Keila",
                Telefone = "992124232",
                Endereco = "Rua Luiza 52",
                Estado = "Em espera",
                Motivo = "Castração",
                Foto = "foto02.png",
                Data = DateTimeOffset.UtcNow
            }
        };

        public IEnumerable<Paciente> GetPacientes()
        {
            return pacientes;
        }

        public Paciente GetPaciente(Guid id)
        {
            return pacientes.Where(paciente => paciente.Id == id).SingleOrDefault();
        }

        public void CreatePaciente(Paciente paciente)
        {
            pacientes.Add(paciente);
        }

        public void UpdatePaciente(Paciente paciente)
        {
            var index = pacientes.FindIndex(existingPaciente => existingPaciente.Id == paciente.Id);
            pacientes[index] = paciente;
        }

        public void DeleteItem(Guid id)
        {
            var index = pacientes.FindIndex(existingPaciente => existingPaciente.Id == id);
            pacientes.RemoveAt(index);
        }
    }
}