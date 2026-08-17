using System.Text.Json.Serialization;

namespace JeromotosWpfApp.Models
{
    public class ServicioTaller
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public bool IsMedible { get; set; }

        public bool Activo { get; set; } = true;

        [JsonIgnore]
        public string Estado
        {
            get
            {
                return Activo ? "Activo" : "Inactivo";
            }
        }

        [JsonIgnore]
        public string Medible
        {
            get
            {
                return IsMedible ? "Medible" : "No Medible";
            }
        }

        [JsonConstructor]
        public ServicioTaller(
            Guid id,
            string nombre,
            string descripcion,
            bool isMedible,
            bool activo = true)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            IsMedible = isMedible;
            Activo = activo;
        }

        public ServicioTaller()
        {
        }
    }

}
