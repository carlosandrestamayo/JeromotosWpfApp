using JeromotosWpfApp.Models;
using System.IO;

namespace JeromotosWpfApp.Repositories
{
    public class ReferenciaRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath = Path.Combine(folder, "referencia.json");

        JsonRepository<Referencia> jsonRepository = new JsonRepository<Referencia>(folder, filePath);

        public List<Referencia> GetAll()
        {
            return jsonRepository
                .GetAll()
                .OrderBy(r => r.Nombre)
                .ToList();
        }

        public void Add(Referencia referencia)
        {
            List<Referencia> lista = jsonRepository.GetAll();

            lista.Add(referencia);

            jsonRepository.Save(lista);
        }

        public void Update(Referencia newReferencia, Guid id)
        {
            jsonRepository.Update(newReferencia, referencia => referencia.Id == id);
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(referencia => referencia.Id == id);
        }

        public Referencia? Find(Guid id)
        {
            return jsonRepository.Find(referencia => referencia.Id == id);
        }

        public bool ExistsByName(string nombre, Guid marcaId)
        {
            return jsonRepository
                .GetAll()
                .Any(r =>
                    r.MarcaId == marcaId &&
                    r.Nombre.Equals(
                        nombre.Trim(),
                        StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistsByName(string nombre, Guid marcaId, Guid excludeId)
        {
            return jsonRepository
                .GetAll()
                .Any(r =>
                    r.Id != excludeId &&
                    r.MarcaId == marcaId &&
                    r.Nombre.Equals(
                        nombre.Trim(),
                        StringComparison.OrdinalIgnoreCase));
        }
    }
}