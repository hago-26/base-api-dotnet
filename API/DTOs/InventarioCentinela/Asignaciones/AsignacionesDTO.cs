using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Core.Entities;

namespace API.DTOs;

public class AsignacionesDto
{
    public int Id { get; set; }
    public CatalogoDto Activo { get; set; }
    public CatalogoDto Resguardante { get; set; }
    public CatalogoDto Municipio { get; set; }
    public string ResguardoUrl { get; set; }
    public string Comentarios { get; set; }

}

public class AsignacionesAddDto
{
    public int? Id { get; set; }
    [Required]
    public int Activo { get; set; }
    [Required]
    public int Resguardante { get; set; }
    [Required]
    public int Municipio { get; set; }
    public string ResguardoUrl { get; set; }
    public string Comentarios { get; set; }
}