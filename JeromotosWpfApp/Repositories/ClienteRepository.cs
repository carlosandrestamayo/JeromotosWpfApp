using JeromotosWpfApp.Models;
using System.IO;

namespace JeromotosWpfApp.Repositories
{
    public class ClienteRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath = Path.Combine(folder, "cliente.json");

        private readonly JsonRepository<Cliente> jsonRepository =
            new JsonRepository<Cliente>(folder, filePath);

        public List<Cliente> GetAll()
        {
            return jsonRepository.GetAll();
        }

        public void Add(Cliente cliente)
        {
            List<Cliente> lista = jsonRepository.GetAll();

            lista.Add(cliente);

            jsonRepository.Save(lista);
        }

        public void Update(Cliente newCliente, Guid personaId)
        {
            jsonRepository.Update(
                newCliente,
                cliente => cliente.PersonaId == personaId
            );
        }

        public void Delete(Guid personaId)
        {
            jsonRepository.Delete(
                cliente => cliente.PersonaId == personaId
            );
        }

        public Cliente? Find(Guid personaId)
        {
            return jsonRepository.Find(
                cliente => cliente.PersonaId == personaId
            );
        }

        public bool ExistsByPersonaId(Guid personaId)
        {
            return jsonRepository
                .GetAll()
                .Any(cliente => cliente.PersonaId == personaId);
        }
    }
}