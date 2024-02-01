
namespace Core.Entities;

public class Producto : CatalogosBase
{
    public string Modelo { get; set; }

    public int MarcaProductoId { get; set; }
    public MarcaProducto MarcaProducto { get; set; }

    public ICollection<Activo> Activos { get; set; }
    public ICollection<Partidas> Partidas { get; set; }
}