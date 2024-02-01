

using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly BaseContext _context;

    // ------------------------------------- REPORITORIOS PRIVADOS -------------------------------------

    // USUARIOS REPOSITORY
    // private IRolRepository _rolRepository;
    // private IUsuarioRepository _usuarioRepository;

    // CATALOGOS CENTINELA 
    private ISubcentroRepository _subcentroRepository;
    private IMunicipioRepository _municipioRepository;
    private IDependenciaRepository _dependenciaRepository;
    private IEmpleadoRepository _empleadoRepository;

    // INVENTARIO CENTINELA
    private IActivoRepository _activoRepository;
    private IProductoRepository _productoRepository;
    private ITipoActivoRepository _tipoActivoRepository;
    private IProveedorRepository _proveedorRepository;
    private IMarcaProductoRepository _marcaProductoRepository;
    private IAsignacionesRepository _asignacionesRepository;
    private IPartidasRepository _partidasRepository;




    public UnitOfWork(BaseContext context)
    {
        _context = context;
    }

    // ------------------------------------- REPORITORIOS SINGLETON -------------------------------------

    // USUARIOS REPOSITORY 
                    // DESCOMENTAR AL IMPLEMENTAR AUTENTICACION POR JWT
    // public IRolRepository RolRepository => _rolRepository ??= new RolesRepository(_context); 
    // public IUsuarioRepository UsuarioRepository => _usuarioRepository ??= new UsuarioRepository(_context);

    // CATALOGOS CENTINELA REPOSITORY
    public ISubcentroRepository SubcentroRepository => _subcentroRepository ??= new SubcentroRepository(_context);
    public IMunicipioRepository MunicipioRepository => _municipioRepository ??= new MunicipioRepository(_context);
    public IDependenciaRepository DependenciaRepository => _dependenciaRepository ??= new DependenciaRepository(_context);
    public IEmpleadoRepository EmpleadoRepository => _empleadoRepository ??= new EmpleadoRepository(_context);

    // INVENTARIO CENTINELA REPOSITORY
    public IActivoRepository ActivoRepository => _activoRepository ??= new ActivoRepository(_context);
    public IProductoRepository ProductoRepository => _productoRepository ??= new ProductoRepository(_context);
    public ITipoActivoRepository TipoActivoRepository => _tipoActivoRepository ??= new TipoActivoRepository(_context);
    public IProveedorRepository ProveedorRepository => _proveedorRepository ??= new ProveedorRepository(_context);
    public IMarcaProductoRepository MarcaProductoRepository => _marcaProductoRepository ??= new MarcaProductoRepository(_context);
    public IAsignacionesRepository AsignacionesRepository => _asignacionesRepository ??= new AsignacionesRepository(_context);

    public IPartidasRepository PartidasRepository => _partidasRepository ??= new PartidasRepository(_context);

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }


    public void Dispose()
    {
        _context.Dispose();
    }
}