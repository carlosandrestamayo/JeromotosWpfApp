using JeromotosWpfApp.Models;
using System.IO;

namespace JeromotosWpfApp.Repositories
{
    public class ReferenciaRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath =
            Path.Combine(folder, "referencia.json");

        private readonly JsonRepository<Referencia> jsonRepository =
            new JsonRepository<Referencia>(folder, filePath);

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
            jsonRepository.Update(
                newReferencia,
                referencia => referencia.Id == id);
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(
                referencia => referencia.Id == id);
        }

        public Referencia? Find(Guid id)
        {
            return jsonRepository.Find(
                referencia => referencia.Id == id);
        }

        public bool ExistsByName(
            string nombre,
            Guid marcaId)
        {
            string nombreNormalizado = NormalizarNombre(nombre);

            return jsonRepository
                .GetAll()
                .Any(r =>
                    r.MarcaId == marcaId &&
                    NormalizarNombre(r.Nombre) == nombreNormalizado);
        }

        public bool ExistsByName(
            string nombre,
            Guid marcaId,
            Guid excludeId)
        {
            string nombreNormalizado = NormalizarNombre(nombre);

            return jsonRepository
                .GetAll()
                .Any(r =>
                    r.Id != excludeId &&
                    r.MarcaId == marcaId &&
                    NormalizarNombre(r.Nombre) == nombreNormalizado);
        }

        private static string NormalizarNombre(string nombre)
        {
            return new string(
                nombre
                    .Where(c => !char.IsWhiteSpace(c))
                    .Where(c => !char.IsPunctuation(c))
                    .ToArray()
            ).ToUpperInvariant();
        }
    }
}
