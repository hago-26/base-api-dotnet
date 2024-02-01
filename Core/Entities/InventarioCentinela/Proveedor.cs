
namespace Core.Entities;

public class Proveedor : CatalogosBase
{
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public string Email { get; set; }

    public ICollection<Activo> Activos { get; set; }
    public ICollection<Partidas> Partidas { get; set; }
}