using System;
using System.Collections.Generic;
using Alojamento.Models;

namespace Alojamento.Data
{
    public interface IPacienteData
    {
        Paciente GetPaciente(Guid id);
        IEnumerable<Paciente> GetPacientes();
        void CreatePaciente(Paciente paciente);
        void UpdatePaciente(Paciente paciente);
        void DeleteItem(Guid id);
    }
}