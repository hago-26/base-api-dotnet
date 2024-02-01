
namespace Core.Entities;

public class MarcaProducto : CatalogosBase
{
    public ICollection<Producto> Productos { get; set; }
}