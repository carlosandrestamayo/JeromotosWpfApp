using JeromotosWpfApp.Models.Enums;
using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class Mantenimiento
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ReferenciaId { get; set; }

        public Guid ServicioTallerId { get; set; }

        public int Intervalo { get; set; }

        public UnidadMantenimiento Unidad { get; set; }

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
        public Mantenimiento(
            Guid id,
            Guid referenciaId,
            Guid servicioTallerId,
            int intervalo,
            UnidadMantenimiento unidad,
            bool activo = true)
        {
            Id = id;
            ReferenciaId = referenciaId;
            ServicioTallerId = servicioTallerId;
            Intervalo = intervalo;
            Unidad = unidad;
            Activo = activo;
        }

        public Mantenimiento()
        {
        }
    }
}