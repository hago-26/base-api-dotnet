using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class MunicipioDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public CatalogoDto Subcentro { get; set; }
    public List<string> Asignaciones { get; set; }
}

public class MunicipioAddDto
{
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; }
    [Required]
    public int Subcentro { get; set; }
}