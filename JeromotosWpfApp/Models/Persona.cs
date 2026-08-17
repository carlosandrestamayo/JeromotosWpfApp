using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Persona
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Documento { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

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
        public Persona(Guid id, string nombre, string documento, string telefono, string email, string direccion, bool activo = true)
        {
            Id = id;
            Nombre = nombre;
            Documento = documento;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            Activo = activo;
        }

        public Persona()
        {

        }

    }
}
