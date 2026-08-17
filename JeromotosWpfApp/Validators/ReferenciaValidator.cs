using JeromotosWpfApp.Models;

namespace JeromotosWpfApp.Validators
{
    public class ReferenciaValidator
    {
        public static string Validate(Referencia referencia)
        {
            if (referencia.MarcaId == Guid.Empty)
            {
                return "La marca es obligatoria.";
            }

            if (string.IsNullOrWhiteSpace(referencia.Nombre))
            {
                return "El nombre es obligatorio.";
            }

            if (referencia.Nombre.Length > 30)
            {
                return "El nombre no puede exceder de 30 caracteres.";
            }

            if (referencia.Cilindraje <= 0)
            {
                return "El cilindraje debe ser mayor que cero.";
            }

            return "";
        }
    }
}