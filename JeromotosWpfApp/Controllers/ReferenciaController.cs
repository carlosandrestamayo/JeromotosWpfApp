using JeromotosWpfApp.Helpers;
using JeromotosWpfApp.Models;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Validators;

namespace JeromotosWpfApp.Controllers
{
    public class ReferenciaController
    {
        private ReferenciaRepository referenciaRepository;

        public ReferenciaController()
        {
            referenciaRepository = new ReferenciaRepository();
        }

        public List<Referencia> GetAll()
        {
            return referenciaRepository.GetAll();
        }

        public string Add(Referencia referencia)
        {
            referencia.Nombre = TextNormalizer.Name(referencia.Nombre);

            string validation = ReferenciaValidator.Validate(referencia);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (referenciaRepository.ExistsByName(
                referencia.Nombre,
                referencia.MarcaId))
            {
                return "Ya existe una referencia con ese nombre para esta marca.";
            }

            referenciaRepository.Add(referencia);

            return "";
        }

        public string Update(Referencia referencia, Guid id)
        {
            referencia.Nombre = TextNormalizer.Name(referencia.Nombre);

            string validation = ReferenciaValidator.Validate(referencia);

            if (!string.IsNullOrEmpty(validation))
            {
                return validation;
            }

            if (referenciaRepository.ExistsByName(
                referencia.Nombre,
                referencia.MarcaId,
                id))
            {
                return "Ya existe una referencia con ese nombre para esta marca.";
            }

            referenciaRepository.Update(referencia, id);

            return "";
        }

        public void Delete(Guid id)
        {
            referenciaRepository.Delete(id);
        }

        public Referencia? Find(Guid id)
        {
            return referenciaRepository.Find(id);
        }
    }
}