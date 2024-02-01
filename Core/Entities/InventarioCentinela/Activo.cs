using System.Text.Json.Serialization;

namespace Core.Entities;


public class Activo : BaseEntityExtended
{
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public int TipoActivoId { get; set; }
    public TipoActivo TipoActivo { get; set; }
    public int ProductoId { get; set; }
    public Producto Producto { get; set; }
    public string NoFactura { get; set; }

    public int? PartidaId { get; set; }
    [JsonIgnore]
    public Partidas Partida { get; set; }
    
    
    public string NoInventario { get; set; }
    public string NoSerie { get; set; }
    public string Comentarios { get; set; }

    public ICollection<Asignaciones> Asignaciones { get; set; }
}