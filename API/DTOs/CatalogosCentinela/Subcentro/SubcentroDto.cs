using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class SubcentroDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<string> Municipios { get; set; }
}

public class SubcentroAddDto 
{
    public int? Id { get; set; }

    [Required]
    public string Nombre { get; set; }
}