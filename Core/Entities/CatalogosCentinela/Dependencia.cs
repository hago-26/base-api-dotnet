
namespace Core.Entities;

public class Dependencia : CatalogosBase
{
    public int? DependenciaPadreId { get; set; }


    
    public Dependencia DependenciaPadre { get; set; }

    public ICollection<Dependencia> DependenciasHijas { get; set; }
    public ICollection<Empleado> Empleados { get; set; }
}