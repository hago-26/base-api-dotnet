
namespace Core.Entities;

public class ModeloProducto : CatalogosBase
{
    public int MarcaProductoId { get; set; }
    public MarcaProducto MarcaProducto { get; set; }

    public ICollection<Producto> Productos { get; set; }
}