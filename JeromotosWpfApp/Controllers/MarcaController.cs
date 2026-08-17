using JeromotosWpfApp.Helpers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Validators;

namespace JeromotosWpfApp.Controllers
{
    public class MarcaController
    {
        private MarcaRepository marcaRepository;

        public MarcaController()
        {
            marcaRepository = new MarcaRepository();
        }

        public List<Marca> GetAll()
        {
            return marcaRepository.GetAll();
        }

        public string Add(Marca marca)
        {
            marca.Nombre = TextNormalizer.Name(marca.Nombre);

            string validation = MarcaValidator.Validate(marca);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (marcaRepository.ExistsByName(marca.Nombre))
            {
                return "Ya existe una marca con ese nombre.";
            }

            marcaRepository.Add(marca);

            return "";
                        
        }

        public string Update(Marca marca, Guid id)
        {
            marca.Nombre = TextNormalizer.Name(marca.Nombre);

            string validation = MarcaValidator.Validate(marca);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (marcaRepository.ExistsByName(marca.Nombre, id))
            {
                return "Ya existe una marca con ese nombre.";
            }

            marcaRepository.Update(marca, id);

            return "";
        }

        public void Delete(Guid id)
        {
            marcaRepository.Delete(id);
        }

        public Marca? Find(Guid id)
        {
            return marcaRepository.Find(id);
        }
    }
}
