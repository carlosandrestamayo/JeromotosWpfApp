using JeromotosWpfApp.Models;

namespace JeromotosWpfApp.Validators
{
    public class MarcaValidator
    {
        public static string Validate(Marca marca)
        {
            
            if (string.IsNullOrWhiteSpace(marca.Nombre))
            {
                return "El nombre es obligatorio.";
            }


            if (marca.Nombre.Length > 20)
            {
                return "El nombre no puede exceder de 20 caracteres.";
            }
                    
            return "";
        }
    }
}
