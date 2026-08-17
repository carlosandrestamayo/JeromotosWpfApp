using JeromotosWpfApp.Models.Enums;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Referencia
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid MarcaId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public int Cilindraje { get; set; }

        public TipoAlimentacion Alimentacion { get; set; }

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
        public Referencia(
            Guid id,
            Guid marcaId,
            string nombre,
            int cilindraje,
            TipoAlimentacion alimentacion,
            bool activo = true)
        {
            Id = id;
            MarcaId = marcaId;
            Nombre = nombre;
            Cilindraje = cilindraje;
            Alimentacion = alimentacion;
            Activo = activo;
        }

        public Referencia()
        {
        }
    }
}