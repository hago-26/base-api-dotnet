using System.ComponentModel.DataAnnotations;
using Core.Entities;

namespace API.DTOs;

public class EmpleadoDto
{
    public int Id { get; set; }
    public int NoEmpleado { get; set; }
    public string Nombre {get; set;}
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public CatalogoDto Dependencia { get; set; }

}

public class EmpleadoAddDto 
{
    public int? Id { get; set; }
    public int NoEmpleado { get; set; }
    [Required]
    public string Nombres { get; set; }
    [Required]
    public string ApellidoPaterno { get; set; }
    [Required]
    public string ApellidoMaterno { get; set; }
    [Required]
    public int Dependencia { get; set; }
}