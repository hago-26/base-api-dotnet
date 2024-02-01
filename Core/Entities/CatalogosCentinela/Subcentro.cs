
namespace Core.Entities;

public class Subcentro : CatalogosBase
{
    public ICollection<Municipio> Municipios { get; set; }
}