using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class TipoActivoDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public ICollection<string> Activos { get; set; }
}

public class TipoActivoAddDto
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
}