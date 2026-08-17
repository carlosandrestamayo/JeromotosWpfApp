using JeromotosWpfApp.Models;

namespace JeromotosWpfApp.Validators
{
    public class MantenimientoValidator
    {
        public static string Validate(Mantenimiento mantenimiento)
        {
            if (mantenimiento.ReferenciaId == Guid.Empty)
            {
                return "Debe seleccionar una referencia.";
            }

            if (mantenimiento.ServicioTallerId == Guid.Empty)
            {
                return "Debe seleccionar un servicio de taller.";
            }

            if (mantenimiento.Intervalo <= 0)
            {
                return "El intervalo debe ser mayor que cero.";
            }

            return "";
        }
    }
}