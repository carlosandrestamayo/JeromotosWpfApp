using JeromotosWpfApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JeromotosWpfApp.Repositories
{
    public class ServicioTallerRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath = Path.Combine(folder, "servicio_taller.json");

        JsonRepository<ServicioTaller> jsonRepository = new JsonRepository<ServicioTaller>(folder, filePath);

        public List<ServicioTaller> GetAll()
        {
            return jsonRepository
                .GetAll()
                .OrderBy(s => s.Nombre)
                .ToList();
        }

        public void Add(ServicioTaller servicioTaller)
        {
            List<ServicioTaller> lista = jsonRepository.GetAll();

            lista.Add(servicioTaller);

            jsonRepository.Save(lista);
        }

        public void Update(
            ServicioTaller newServicioTaller,
            Guid id)
        {
            jsonRepository.Update(
                newServicioTaller,
                servicioTaller => servicioTaller.Id == id
            );
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(
                servicioTaller => servicioTaller.Id == id
            );
        }

        public ServicioTaller? Find(Guid id)
        {
            return jsonRepository.Find(
                servicioTaller => servicioTaller.Id == id
            );
        }

        public bool ExistsByName(string nombre)
        {
            return jsonRepository
                .GetAll()
                .Any(s => s.Nombre.Equals(
                    nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase));
        }

        public bool ExistsByName(
            string nombre,
            Guid excludeId)
        {
            return jsonRepository
                .GetAll()
                .Any(s =>
                    s.Id != excludeId &&
                    s.Nombre.Equals(
                        nombre.Trim(),
                        StringComparison.OrdinalIgnoreCase));
        }
    }
}