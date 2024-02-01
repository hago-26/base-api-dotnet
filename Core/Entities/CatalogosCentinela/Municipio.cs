
namespace Core.Entities;

public class Municipio : CatalogosBase
{
    public int SubcentroId { get; set; }

    
    public Subcentro Subcentro { get; set; } 

    public ICollection<Asignaciones> Asignaciones { get; set; }
  
}