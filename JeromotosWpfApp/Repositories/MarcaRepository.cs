using JeromotosWpfApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media.Media3D;

namespace JeromotosWpfApp.Repositories
{
    public class MarcaRepository
    {
        private static readonly string folder = "Data";
        private static readonly string filePath = Path.Combine(folder, "marca.json");

        JsonRepository<Marca> jsonRepository = new JsonRepository<Marca>(folder, filePath);

        public List<Marca> GetAll()
        {
            return jsonRepository
                .GetAll()
                .OrderBy(m => m.Nombre)
                .ToList();
        }


        public void Add(Marca marca)
        {
            List<Marca> lista = jsonRepository.GetAll();

            lista.Add(marca);

            jsonRepository.Save(lista);
        }


        public void Update(Marca newMarca, Guid id)
        {
            jsonRepository.Update(newMarca, marca => marca.Id == id);
        }

        public void Delete(Guid id)
        {
            jsonRepository.Delete(marca => marca.Id == id);
        }

        public Marca? Find(Guid id)
        {
            return jsonRepository.Find(marca => marca.Id == id);
        }

        public bool ExistsByName(string nombre)
        {
            return jsonRepository
                .GetAll()
                .Any(m => m.Nombre.Equals(
                    nombre.Trim(),
                    StringComparison.OrdinalIgnoreCase));
        }
        public bool ExistsByName(string nombre, Guid excludeId)
        {
            return jsonRepository
                .GetAll()
                .Any(m =>
                    m.Id != excludeId &&
                    m.Nombre.Equals(
                        nombre.Trim(),
                        StringComparison.OrdinalIgnoreCase));
        }
    }
}
