using JeromotosWpfApp.Helpers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Validators;

namespace JeromotosWpfApp.Controllers
{
    public class ServicioTallerController
    {
        private ServicioTallerRepository servicioTallerRepository;

        public ServicioTallerController()
        {
            servicioTallerRepository = new ServicioTallerRepository();
        }

        public List<ServicioTaller> GetAll()
        {
            return servicioTallerRepository.GetAll();
        }

        public string Add(ServicioTaller servicioTaller)
        {
            servicioTaller.Nombre =
                TextNormalizer.Name(servicioTaller.Nombre);

            servicioTaller.Descripcion =
                TextNormalizer.Name(servicioTaller.Descripcion);

            string validation =
                ServicioTallerValidator.Validate(servicioTaller);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (servicioTallerRepository.ExistsByName(
                servicioTaller.Nombre))
            {
                return "Ya existe un servicio con ese nombre.";
            }

            servicioTallerRepository.Add(servicioTaller);

            return "";
        }

        public string Update(
            ServicioTaller servicioTaller,
            Guid id)
        {
            servicioTaller.Nombre =
                TextNormalizer.Name(servicioTaller.Nombre);

            servicioTaller.Descripcion =
                TextNormalizer.Name(servicioTaller.Descripcion);

            string validation =
                ServicioTallerValidator.Validate(servicioTaller);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (servicioTallerRepository.ExistsByName(
                servicioTaller.Nombre,
                id))
            {
                return "Ya existe un servicio con ese nombre.";
            }

            servicioTallerRepository.Update(
                servicioTaller,
                id);

            return "";
        }

        public void Delete(Guid id)
        {
            servicioTallerRepository.Delete(id);
        }

        public ServicioTaller? Find(Guid id)
        {
            return servicioTallerRepository.Find(id);
        }
    }
}