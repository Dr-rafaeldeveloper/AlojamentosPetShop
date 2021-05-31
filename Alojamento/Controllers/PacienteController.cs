using System;
using System.Collections.Generic;
using System.Linq;
using Alojamento.Data;
using Alojamento.Dtos;
using Alojamento.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alojamento.Controllers
{

    [ApiController]
    [Route("pacientes")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteData pacienteData;

        public PacienteController(IPacienteData pacienteData)
        {
            this.pacienteData = pacienteData;
        }

        //GET /pacientes
        [HttpGet]
        public IEnumerable<PacienteDto> GetPacientes() 
        {
            var pacientes = pacienteData.GetPacientes().Select(paciente => paciente.AsDto());
            
            return pacientes;
        }

        //GET /pacientes/{id}
        [HttpGet("{id}")]
        public ActionResult<PacienteDto> GetPaciente(Guid id)
        {
            var paciente = pacienteData.GetPaciente(id);

            if(paciente is null)
            {
                return NotFound();
            }
            return paciente.AsDto();
        }

        //POST /pacientes/
        [HttpPost]

        public ActionResult<PacienteDto> CreatePaciente(CreatePacienteDto pacienteDto)
        {
            Paciente paciente = new()
            {
                Id = Guid.NewGuid(),
                Nome = pacienteDto.Nome,
                NomeProp = pacienteDto.NomeProp,
                Telefone = pacienteDto.Telefone,
                Endereco = pacienteDto.Endereco,
                Estado = pacienteDto.Estado,
                Motivo = pacienteDto.Motivo,
                Foto = pacienteDto.Foto,
                Data = DateTimeOffset.UtcNow
            };

            pacienteData.CreatePaciente(paciente);

            return CreatedAtAction(nameof(GetPaciente), new { id = paciente.Id }, paciente.AsDto());
        }

        //PUT /pacientes/{id}
        [HttpPut("{id}")]

        public ActionResult UpdatePaciente(Guid id, UpdatePacienteDto pacienteDto)
        {
            var existingPaciente = pacienteData.GetPaciente(id);

            if(existingPaciente is null)
            {
                return NotFound();
            }

            Paciente updatedPaciente = existingPaciente with
            {
                Nome = pacienteDto.Nome,
                NomeProp = pacienteDto.NomeProp,
                Telefone = pacienteDto.Telefone,
                Endereco = pacienteDto.Endereco,
                Estado = pacienteDto.Estado,
                Motivo = pacienteDto.Motivo,
                Foto = pacienteDto.Foto,
            };

            pacienteData.UpdatePaciente(updatedPaciente);
            
            return NoContent();
        }

        //DELETE /pacientes/{id}

        [HttpDelete("{id}")]

        public ActionResult DeletePaciente(Guid id)
        {
            var existingPaciente = pacienteData.GetPaciente(id);

            if(existingPaciente is null)
            {
                return NotFound();
            }

            pacienteData.DeleteItem(id);

            return NoContent();
        } 
    }
}