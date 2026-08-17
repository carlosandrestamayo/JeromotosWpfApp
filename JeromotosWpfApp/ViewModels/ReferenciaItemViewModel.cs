using JeromotosWpfApp.Models;
using JeromotosWpfApp.Models.Enums;

namespace JeromotosWpfApp.ViewModels
{
    public class ReferenciaItemViewModel
    {
        public Guid Id { get; set; }

        public Guid MarcaId { get; set; }

        public string MarcaNombre { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;

        public int Cilindraje { get; set; }

        public TipoAlimentacion Alimentacion { get; set; }

        public bool Activo { get; set; }

        public string Estado
        {
            get
            {
                return Activo ? "Activo" : "Inactivo";
            }
        }
    }
}