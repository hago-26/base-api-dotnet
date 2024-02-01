

namespace Core.Entities;

public class BaseEntity
{
    public int Id { get; set; }
}

public class BaseEntityExtended : BaseEntity
{
    // User
    // Fecha de creacion
    // Fecha de modificacion
    // Estado

    public DateTime FechaCreacion { get; set; }
    public DateTime FechaModificacion { get; set; }

}

public class CatalogosBase : BaseEntity
{
    public string Nombre { get; set; }
}

