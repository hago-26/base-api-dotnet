using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class BaseContext: DbContext
{
    // Catalogos Centinela
    public DbSet<Subcentro> Subcentros { get; set; }
    public DbSet<Municipio> Municipios { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
    public DbSet<Dependencia> Dependencias { get; set; }

    // Inventario Centinela
    public DbSet<Partidas> Partidas { get; set; }
    public DbSet<TipoActivo> TiposActivos { get; set; }
    public DbSet<MarcaProducto> MarcaProductos { get; set; }
    public DbSet<Activo> Activos { get; set; }
    public DbSet<Producto> Productos { get; set; }
    public DbSet<Proveedor> Proveedores { get; set; }
    public DbSet<Asignaciones> Asignaciones { get; set; }

    public BaseContext(DbContextOptions<BaseContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
