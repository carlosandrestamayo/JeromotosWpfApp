using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Marca
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

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
        public Marca(Guid id, string nombre, bool activo = true)
        {
            Id = id;
            Nombre = nombre;
            Activo = activo;
        }

        public Marca()
        {

        }
    }
}
