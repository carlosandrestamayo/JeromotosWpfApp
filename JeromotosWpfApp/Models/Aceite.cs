using System;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Aceite
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Marca { get; set; } = string.Empty;

        public string Referencia { get; set; } = string.Empty;

        public string Viscosidad { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

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
        public Aceite(
            Guid id,
            string marca,
            string referencia,
            string viscosidad,
            string tipo,
            bool activo = true)
        {
            Id = id;
            Marca = marca;
            Referencia = referencia;
            Viscosidad = viscosidad;
            Tipo = tipo;
            Activo = activo;
        }

        public Aceite()
        {
        }
    }
}