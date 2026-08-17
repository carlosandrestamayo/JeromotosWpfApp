using JeromotosWpfApp.Models;
using JeromotosWpfApp.Repositories;
using JeromotosWpfApp.Validators;

namespace JeromotosWpfApp.Controllers
{
    public class MantenimientoController
    {
        private readonly MantenimientoRepository mantenimientoRepository =
            new MantenimientoRepository();

        private readonly ReferenciaRepository referenciaRepository =
            new ReferenciaRepository();

        private readonly ServicioTallerRepository servicioTallerRepository =
            new ServicioTallerRepository();

        public List<Mantenimiento> GetAll()
        {
            return mantenimientoRepository.GetAll();
        }

        public Mantenimiento? Find(Guid id)
        {
            return mantenimientoRepository.Find(id);
        }

        public string Add(Mantenimiento mantenimiento)
        {
            string validationMessage =
                MantenimientoValidator.Validate(mantenimiento);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                return validationMessage;
            }

            Referencia? referencia =
                referenciaRepository.Find(mantenimiento.ReferenciaId);

            if (referencia == null)
            {
                return "La referencia seleccionada no existe.";
            }

            if (!referencia.Activo)
            {
                return "La referencia seleccionada está inactiva.";
            }

            ServicioTaller? servicio =
                servicioTallerRepository.Find(
                    mantenimiento.ServicioTallerId);

            if (servicio == null)
            {
                return "El servicio de taller seleccionado no existe.";
            }

            if (!servicio.Activo)
            {
                return "El servicio de taller seleccionado está inactivo.";
            }

            if (!servicio.IsMedible)
            {
                return "El servicio seleccionado no es medible y no puede agregarse a la tabla de mantenimiento.";
            }

            if (mantenimientoRepository.Exists(
                    mantenimiento.ReferenciaId,
                    mantenimiento.ServicioTallerId))
            {
                return "Este servicio ya está configurado para la referencia seleccionada.";
            }

            mantenimientoRepository.Add(mantenimiento);

            return "";
        }

        public string Update(
            Mantenimiento newMantenimiento,
            Guid id)
        {
            string validationMessage =
                MantenimientoValidator.Validate(newMantenimiento);

            if (!string.IsNullOrEmpty(validationMessage))
            {
                return validationMessage;
            }

            Mantenimiento? existing =
                mantenimientoRepository.Find(id);

            if (existing == null)
            {
                return "El mantenimiento no existe.";
            }

            Referencia? referencia =
                referenciaRepository.Find(
                    newMantenimiento.ReferenciaId);

            if (referencia == null)
            {
                return "La referencia seleccionada no existe.";
            }

            if (!referencia.Activo)
            {
                return "La referencia seleccionada está inactiva.";
            }

            ServicioTaller? servicio =
                servicioTallerRepository.Find(
                    newMantenimiento.ServicioTallerId);

            if (servicio == null)
            {
                return "El servicio de taller seleccionado no existe.";
            }

            if (!servicio.Activo)
            {
                return "El servicio de taller seleccionado está inactivo.";
            }

            if (!servicio.IsMedible)
            {
                return "El servicio seleccionado no es medible y no puede utilizarse en la tabla de mantenimiento.";
            }

            if (mantenimientoRepository.Exists(
                    newMantenimiento.ReferenciaId,
                    newMantenimiento.ServicioTallerId,
                    id))
            {
                return "Este servicio ya está configurado para la referencia seleccionada.";
            }

            newMantenimiento.Id = id;

            mantenimientoRepository.Update(
                newMantenimiento,
                id);

            return "";
        }

        public string Delete(Guid id)
        {
            Mantenimiento? mantenimiento =
                mantenimientoRepository.Find(id);

            if (mantenimiento == null)
            {
                return "El mantenimiento no existe.";
            }

            mantenimientoRepository.Delete(id);

            return "";
        }
    }
}