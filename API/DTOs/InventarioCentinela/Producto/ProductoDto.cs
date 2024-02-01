using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class ProductoDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Modelo { get; set; }
    public CatalogoDto Marca { get; set; }
    public List<string> Activos { get; set; }
}

public class ProductoAddDto
{
    public int? Id { get; set; }

    [Required]
    public string Nombre { get; set; }
    public string Modelo { get; set; }
    public int Marca { get; set; }
}