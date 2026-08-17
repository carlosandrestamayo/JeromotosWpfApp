using JeromotosWpfApp.Models;

namespace JeromotosWpfApp.Validators
{
    public class PersonaValidator
    {
        public static string Validate(Persona persona)
        {
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                return "El nombre es obligatorio.";
            }

            if (persona.Nombre.Length > 100)
            {
                return "El nombre no puede exceder de 100 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(persona.Documento))
            {
                return "El documento es obligatorio.";
            }

            if (persona.Documento.Length > 20)
            {
                return "El documento no puede exceder de 20 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(persona.Telefono))
            {
                return "El teléfono es obligatorio.";
            }

            if (persona.Telefono.Length > 20)
            {
                return "El teléfono no puede exceder de 20 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(persona.Email))
            {
                return "El correo electrónico es obligatorio.";
            }

            if (persona.Email.Length > 100)
            {
                return "El correo electrónico no puede exceder de 100 caracteres.";
            }

            if (string.IsNullOrWhiteSpace(persona.Direccion))
            {
                return "La dirección es obligatoria.";
            }

            if (persona.Direccion.Length > 150)
            {
                return "La dirección no puede exceder de 150 caracteres.";
            }

            return "";
        }
    }
}