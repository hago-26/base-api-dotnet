using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class ProveedorDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
    public ICollection<string> Activos { get; set; }
    
}

public class ProveedorAddDto 
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }
}