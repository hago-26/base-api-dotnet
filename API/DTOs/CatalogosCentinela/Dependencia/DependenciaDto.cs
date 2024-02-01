using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class DependenciaDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public CatalogoDto DependenciaPadre { get; set; }
    public List<string> DependenciasHijas { get; set; }
    public List<string> Empleados { get; set; }
}

public class DependenciaAddDto
{
    public int? Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public int? DependenciaPadre { get; set; }
}