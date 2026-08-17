using JeromotosWpfApp.Models;
using System.IO;

namespace JeromotosWpfApp.Repositories
{
    public class MantenimientoRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath =
            Path.Combine(folder, "mantenimiento.json");

        private readonly JsonRepository<Mantenimiento> jsonRepository =
            new JsonRepository<Mantenimiento>(folder, filePath);

        public List<Mantenimiento> GetAll()
        {
            return jsonRepository
                .GetAll()
                .OrderBy(m => m.Intervalo)
                .ToList();
        }

        public void Add(Mantenimiento mantenimiento)
        {
            List<Mantenimiento> lista = jsonRepository.GetAll();

            lista.Add(mantenimiento);

            jsonRepository.Save(lista);
        }

        public void Update(
            Mantenimiento newMantenimiento,
            Guid id)
        {
            jsonRepository.Update(
                newMantenimiento,
                mantenimiento => mantenimiento.Id == id);
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(
                mantenimiento => mantenimiento.Id == id);
        }

        public Mantenimiento? Find(Guid id)
        {
            return jsonRepository.Find(
                mantenimiento => mantenimiento.Id == id);
        }

        public bool Exists(
            Guid referenciaId,
            Guid servicioTallerId)
        {
            return jsonRepository
                .GetAll()
                .Any(m =>
                    m.ReferenciaId == referenciaId &&
                    m.ServicioTallerId == servicioTallerId);
        }

        public bool Exists(
            Guid referenciaId,
            Guid servicioTallerId,
            Guid excludeId)
        {
            return jsonRepository
                .GetAll()
                .Any(m =>
                    m.Id != excludeId &&
                    m.ReferenciaId == referenciaId &&
                    m.ServicioTallerId == servicioTallerId);
        }
    }
}