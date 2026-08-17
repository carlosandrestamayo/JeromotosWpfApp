using JeromotosWpfApp.Helpers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Validators;

namespace JeromotosWpfApp.Controllers
{
    public class ClienteController
    {
        private readonly PersonaRepository personaRepository;
        private readonly ClienteRepository clienteRepository;

        public ClienteController()
        {
            personaRepository = new PersonaRepository();
            clienteRepository = new ClienteRepository();
        }

        public List<Persona> GetAll()
        {
            return personaRepository.GetAll()
                .Where(persona => clienteRepository.ExistsByPersonaId(persona.Id))
                .ToList();
        }

        public string Add(Persona persona)
        {
            persona.Nombre = TextNormalizer.Name(persona.Nombre);
            persona.Documento = persona.Documento.Trim();
            persona.Telefono = persona.Telefono.Trim();
            persona.Email = persona.Email.Trim().ToLower();
            persona.Direccion = persona.Direccion.Trim();

            string validation = PersonaValidator.Validate(persona);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (personaRepository.ExistsByDocument(persona.Documento))
            {
                return "Ya existe una persona con ese documento.";
            }

            if (clienteRepository.ExistsByPersonaId(persona.Id))
            {
                return "La persona ya está registrada como cliente.";
            }

            personaRepository.Add(persona);

            Cliente cliente = new Cliente(persona.Id);

            clienteRepository.Add(cliente);

            return "";
        }

        public string Update(Persona persona, Guid id)
        {
            persona.Nombre = TextNormalizer.Name(persona.Nombre);
            persona.Documento = persona.Documento.Trim();
            persona.Telefono = persona.Telefono.Trim();
            persona.Email = persona.Email.Trim().ToLower();
            persona.Direccion = persona.Direccion.Trim();

            string validation = PersonaValidator.Validate(persona);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (personaRepository.ExistsByDocument(persona.Documento, id))
            {
                return "Ya existe una persona con ese documento.";
            }

            personaRepository.Update(persona, id);

            return "";
        }

        public void Delete(Guid personaId)
        {
            clienteRepository.Delete(personaId);
        }

        public Persona? Find(Guid personaId)
        {
            return personaRepository.Find(personaId);
        }
    }
}