using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Cliente
    {
        public Guid PersonaId { get; set; }

        [JsonConstructor]
        public Cliente(Guid personaId)
        {
            PersonaId = personaId;
        }

        public Cliente()
        {
        }
    }
}
