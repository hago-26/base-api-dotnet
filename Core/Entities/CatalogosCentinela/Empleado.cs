
namespace Core.Entities;

public class Empleado : BaseEntityExtended
{
    public int NoEmpleado { get; set; }
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }

    public int DependenciaId { get; set; }
    public Dependencia Dependencia { get; set; }

    public string GetNombreCompleto()
    {
        return $"{Nombres} {ApellidoPaterno} {ApellidoMaterno}";
    }

    public ICollection<Asignaciones> Asignaciones { get; set; }


}