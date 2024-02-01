using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class PartidasDto 
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public CatalogoDto Producto { get; set; }
    public string NoFactura { get; set; }
    public CatalogoDto Proveedor { get; set; }
    public CatalogoDto TipoActivo { get; set; }
    public int Cantidad { get; set; }
    public int CantidadRestante { get; set; }
    public ICollection<CatalogoDto> Activos { get; set; }

}

public class PartidasAddDto
{
    public int Id { get; set; }
    [Required]
    public int Producto { get; set; }
    [Required]
    public int Proveedor { get; set; }
    [Required]
    public int TipoActivo { get; set; }
    [Required]
    public int Cantidad { get; set; }
    public string NoFactura { get; set; }
}
