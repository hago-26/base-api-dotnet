
namespace Core.Entities;

public class TipoActivo : CatalogosBase
{
    public string Descripcion { get; set; }

    public ICollection<Activo> Activos { get; set; }
    public ICollection<Partidas> Partidas { get; set; }
}