

using Core.Interfaces;

public interface IUnitOfWork
{
    // ------------------------------------- REPORITORIOS -------------------------------------
    // USUARIOS REPOSITORY
                    // DESCOMENTAR AL IMPLEMENTAR AUTENTICACION POR JWT
    // IRolRepository RolRepository { get; }
    // IUsuarioRepository UsuarioRepository { get; }


    // CATALOGOS CENTINELA REPOSITORY
    ISubcentroRepository SubcentroRepository { get; }
    IMunicipioRepository MunicipioRepository { get; }
    IDependenciaRepository DependenciaRepository { get; }
    IEmpleadoRepository EmpleadoRepository { get; }

    // INVENTARIO CENTINELA REPOSITORY
    IActivoRepository ActivoRepository { get; }
    IPartidasRepository PartidasRepository { get; }
    IProductoRepository ProductoRepository { get; }
    ITipoActivoRepository TipoActivoRepository { get; }
    IProveedorRepository ProveedorRepository { get; }
    IMarcaProductoRepository MarcaProductoRepository { get; }
    IAsignacionesRepository AsignacionesRepository { get; }

    

    Task<int> CompleteAsync();
}