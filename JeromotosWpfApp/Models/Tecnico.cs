using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Tecnico
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid PersonaId { get; set; }

        public string Especialidad { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        [JsonIgnore]
        public string Estado
        {
            get
            {
                return Activo ? "Activo" : "Inactivo";
            }
        }

        [JsonConstructor]
        public Tecnico(
            Guid id,
            Guid personaId,
            string especialidad,
            bool activo = true)
        {
            Id = id;
            PersonaId = personaId;
            Especialidad = especialidad;
            Activo = activo;
        }

        public Tecnico()
        {
        }
    }
}
