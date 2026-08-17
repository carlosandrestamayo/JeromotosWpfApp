using JeromotosWpfApp.Models;
using JeromotosWpfApp.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace JeromotosWpfApp.Repositories
{
    public class MarcaRepository
    {
        public List<Marca> GetAll()
        {
            using var db = new JeromotosDbContext();

            return db.Marcas
                .OrderBy(m => m.Nombre)
                .ToList();
        }

        public void Add(Marca marca)
        {
            using var db = new JeromotosDbContext();

            db.Marcas.Add(marca);
            db.SaveChanges();
        }

        public void Update(Marca newMarca, Guid id)
        {
            using var db = new JeromotosDbContext();

            var marca = db.Marcas
                .FirstOrDefault(m => m.Id.ToString() == id.ToString());

            MessageBox.Show((marca != null).ToString());

            if (marca != null)
            {
                marca.Nombre = newMarca.Nombre;
                marca.Activo = newMarca.Activo;

                db.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            using var db = new JeromotosDbContext();

            var marca = db.Marcas
                .FirstOrDefault(m => m.Id.ToString() == id.ToString());

            if (marca != null)
            {
                db.Marcas.Remove(marca);
                db.SaveChanges();
            }
        }

        public Marca? Find(Guid id)
        {
            using var db = new JeromotosDbContext();

            return db.Marcas
                .FirstOrDefault(m => m.Id.ToString() == id.ToString());
        }

        public bool ExistsByName(string nombre)
        {
            using var db = new JeromotosDbContext();

            return db.Marcas.Any(m =>
                m.Nombre.ToLower() == nombre.Trim().ToLower());
        }

        public bool ExistsByName(string nombre, Guid excludeId)
        {
            using var db = new JeromotosDbContext();

            return db.Marcas.Any(m =>
                m.Id != excludeId &&
                m.Nombre.ToLower() == nombre.Trim().ToLower());
        }
    }
}