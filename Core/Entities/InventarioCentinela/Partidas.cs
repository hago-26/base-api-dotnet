
using System.Collections;

namespace Core.Entities;

public class Partidas : BaseEntityExtended
{
    public int ProveedorId { get; set; }
    public Proveedor Proveedor { get; set; }
    public int TipoActivoId { get; set; }
    public TipoActivo TipoActivo { get; set; }
    public int ProductoId { get; set; }
    public Producto Producto { get; set; }
    public string NoFactura { get; set; } 
    
    public int Cantidad { get; set; }

    public ICollection<Activo> Activos { get; set; }


    public int GetCantidadRestante()
    {
        if (Activos == null)
        {
            return Cantidad;
        }

        return Cantidad - Activos.Count;
    }

    public string GetNombrePartida()
    {
        return $"{Producto.Nombre} - {Proveedor.Nombre}";
    }
}