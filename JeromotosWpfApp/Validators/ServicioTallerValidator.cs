using JeromotosWpfApp.Models;

namespace JeromotosWpfApp.Validators
{
    public class ServicioTallerValidator
    {
        public static string Validate(ServicioTaller servicioTaller)
        {
            if (string.IsNullOrWhiteSpace(servicioTaller.Nombre))
            {
                return "El nombre es obligatorio.";
            }

            if (servicioTaller.Nombre.Length > 50)
            {
                return "El nombre no puede exceder de 50 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(servicioTaller.Descripcion))
            {
                //return "La descripción es obligatoria.";
            }

            if (servicioTaller.Descripcion.Length > 200)
            {
                //return "La descripción no puede exceder de 200 caracteres.";
            }

            return "";
        }
    }
}