using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class MarcaProductoDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public List<CatalogoDto> Productos { get; set; }

}

public class MarcaProductoAddDto 
{
    public int? Id { get; set; }
    [Required]
    public string Nombre { get; set; }
}