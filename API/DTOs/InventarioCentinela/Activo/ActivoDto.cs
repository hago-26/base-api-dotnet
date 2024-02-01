using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class ActivoDto 
{
    public int Id { get; set; }
    public CatalogoDto Producto { get; set; }
    public string Nombre { get; set; }
    public string NoInventario { get; set; }
    public string NoSerie { get; set; }
    public string NoFactura { get; set; }
    public CatalogoDto Proveedor { get; set; }
    public CatalogoDto TipoActivo { get; set; }
    public CatalogoDto Partida { get; set; }
    public string Comentarios { get; set; }

}

public class ActivoAddDto
{
    public int? Id { get; set; }
    [Required]
    public int Producto { get; set; }
    [Required]
    public string NoInventario { get; set; }
    [Required]
    public string NoSerie { get; set; }
    public string NoFactura { get; set; }
    [Required]
    public int Proveedor { get; set; }
    [Required]
    public int TipoActivo { get; set; }
    public string Comentarios { get; set; }
    public int? Partida { get; set; }
}

public class ActivoFromPartidaAddDto
{
    public int? Id { get; set; }
    [Required]
    public int Partida { get; set; }
    public string Comentarios { get; set; }
    [Required]
    public string NoSerie { get; set; }
    [Required]
    public string NoInventario { get; set; }


}