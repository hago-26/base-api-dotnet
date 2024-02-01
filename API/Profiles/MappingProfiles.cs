using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // Helper
        // CreateMap<Source, Destination>();
        // ForMember(dest => dest.DestProperty, opt => opt.MapFrom(src => src.SrcProperty)); 
                

        CreateMap<Municipio, MunicipioDto>()
            .ForMember(d => d.Subcentro, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Subcentro.Nombre, Id = src.Subcentro.Id }))
            .ForMember(d => d.Asignaciones, x => x.MapFrom(src => src.Asignaciones.Select(x => x.Activo.Producto.Nombre).ToList()))
            .ReverseMap();

        CreateMap<MunicipioAddDto, Municipio>()
            .ForMember(d => d.SubcentroId, x => x.MapFrom(src => src.Subcentro))
            .ForMember(d => d.Subcentro, x => x.Ignore());

        CreateMap<Subcentro, SubcentroDto>()
            .ForMember(d => d.Municipios, x => x.MapFrom(src => src.Municipios.Select(x => x.Nombre).ToList()))
            .ReverseMap();
        
        CreateMap<SubcentroAddDto, Subcentro>();

        CreateMap<Activo, ActivoDto>()
            .ForMember(d => d.Nombre, x => x.MapFrom(src => src.Producto.Nombre))
            .ForMember(d => d.Partida, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Partida.Producto.Nombre, Id = src.Partida.Id }))
            .ForMember(d => d.Producto, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Producto.Nombre, Id = src.Producto.Id }))
            .ForMember(d => d.Proveedor, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Proveedor.Nombre, Id = src.Proveedor.Id }))
            .ForMember(d => d.TipoActivo, x => x.MapFrom(src => new CatalogoDto { Nombre = src.TipoActivo.Nombre, Id = src.TipoActivo.Id }))
            .ReverseMap();

        CreateMap<ActivoAddDto, Activo>()
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.Producto))
            .ForMember(dest => dest.Producto, opt => opt.Ignore())
            .ForMember(dest => dest.ProveedorId, opt => opt.MapFrom(src => src.Proveedor))
            .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
            .ForMember(dest => dest.TipoActivoId, opt => opt.MapFrom(src => src.TipoActivo))
            .ForMember(dest => dest.TipoActivo, opt => opt.Ignore())
            .ForMember(dest => dest.PartidaId, opt => opt.MapFrom(src => src.Partida))
            .ForMember(dest => dest.Partida, opt => opt.Ignore());

        CreateMap<Partidas, Activo>()
            .ForMember(dest => dest.ProveedorId, opt => opt.MapFrom(src => src.ProveedorId))
            .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
            .ForMember(dest => dest.TipoActivoId, opt => opt.MapFrom(src => src.TipoActivoId))
            .ForMember(dest => dest.TipoActivo, opt => opt.Ignore())
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
            .ForMember(dest => dest.Producto, opt => opt.Ignore())
            .ForMember(dest => dest.PartidaId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Partida, opt => opt.Ignore())
            .ForMember(dest => dest.NoFactura, opt => opt.MapFrom(src => src.NoFactura))
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ReverseMap();
            
        CreateMap<MarcaProducto, MarcaProductoDto>()
            .ForMember(d => d.Productos, x => x.MapFrom(src => src.Productos.Select(x => new CatalogoDto {Nombre = x.Nombre, Id=x.Id}).ToList()))
            .ReverseMap();

        CreateMap<MarcaProductoAddDto, MarcaProducto>();

        CreateMap<Producto, ProductoDto>()
            .ForMember(d => d.Marca, x => x.MapFrom(src => new CatalogoDto { Nombre = src.MarcaProducto.Nombre, Id = src.MarcaProducto.Id }))
            .ForMember(d => d.Activos, x => x.MapFrom(src => src.Activos.Select(x => x.NoInventario).ToList()))
            .ReverseMap();

        CreateMap<ProductoAddDto, Producto>()
            .ForMember(dest => dest.MarcaProductoId, opt => opt.MapFrom(src => src.Marca))
            .ForMember(dest => dest.MarcaProducto, opt => opt.Ignore());

        CreateMap<Dependencia, DependenciaDto>()

            .ForMember(d => d.DependenciaPadre, x => x.MapFrom(src => new CatalogoDto { Nombre = src.DependenciaPadre.Nombre, Id = src.DependenciaPadre.Id }))
            .ForMember(d => d.DependenciasHijas, x => x.MapFrom(src => src.DependenciasHijas.Select(x => new {Nombre=x.Nombre, Id=x.Id}).ToList()))
            .ForMember(d => d.Empleados, x => x.MapFrom(src => src.Empleados.Select(x => new {Nombre=x.Nombres, Id=x.NoEmpleado}).ToList()))
            .ReverseMap();

        // CreateMap<Dependencia, DependenciaAddDto>()
        CreateMap<DependenciaAddDto, Dependencia>()
            .ForMember(dest => dest.DependenciaPadreId, opt => opt.MapFrom(src => src.DependenciaPadre))
            .ForMember(dest => dest.DependenciaPadre, opt => opt.Ignore());
            
        CreateMap<Empleado, EmpleadoDto>()
            .ForMember(d => d.Nombre, x => x.MapFrom(src => src.GetNombreCompleto()))
            .ForMember(d => d.Dependencia, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Dependencia.Nombre, Id = src.Dependencia.Id }))
            .ReverseMap();

        CreateMap<EmpleadoAddDto, Empleado>()
            .ForMember(dest => dest.DependenciaId, opt => opt.MapFrom(src => src.Dependencia))
            .ForMember(dest => dest.Dependencia, opt => opt.Ignore());

        CreateMap<Proveedor, ProveedorDto>()
            .ForMember(d => d.Activos, x => x.MapFrom(src => src.Activos.Select(x => x.NoInventario).ToList()))
            .ReverseMap();
        
        CreateMap<ProveedorAddDto, Proveedor>();

        CreateMap<TipoActivo, TipoActivoDto>()
            .ForMember(d => d.Activos, x => x.MapFrom(src => src.Activos.Select(x => x.NoInventario).ToList()))
            .ReverseMap();

        CreateMap<TipoActivoAddDto, TipoActivo>();

        CreateMap<Asignaciones, AsignacionesDto>()
            .ForMember(d => d.Activo, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Activo.Producto.Nombre, Id = src.Activo.Producto.Id }))
            .ForMember(d => d.Resguardante, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Resguardante.GetNombreCompleto(), Id = src.Resguardante.Id }))
            .ForMember(d => d.Municipio, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Municipio.Nombre, Id = src.Municipio.Id }))            
            .ReverseMap();

        CreateMap<AsignacionesAddDto, Asignaciones>()
            .ForMember(dest => dest.ActivoId, opt => opt.MapFrom(src => src.Activo))
            .ForMember(dest => dest.Activo, opt => opt.Ignore())
            .ForMember(dest => dest.ResguradanteId, opt => opt.MapFrom(src => src.Resguardante))
            .ForMember(dest => dest.Resguardante, opt => opt.Ignore())
            .ForMember(dest => dest.MunicipioId, opt => opt.MapFrom(src => src.Municipio))
            .ForMember(dest => dest.Municipio, opt => opt.Ignore());

        CreateMap<Partidas, PartidasDto>()
            .ForMember(d => d.Producto, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Producto.Nombre, Id = src.Producto.Id }))
            .ForMember(d => d.Proveedor, x => x.MapFrom(src => new CatalogoDto { Nombre = src.Proveedor.Nombre, Id = src.Proveedor.Id }))
            .ForMember(d => d.TipoActivo, x => x.MapFrom(src => new CatalogoDto { Nombre = src.TipoActivo.Nombre, Id = src.TipoActivo.Id }))
            .ForMember(d => d.Activos, x => x.MapFrom(src => src.Activos.Select(x => new CatalogoDto {Nombre = x.Producto.Nombre, Id=x.Id}).ToList()))
            .ForMember(d => d.CantidadRestante, x => x.MapFrom(src => src.GetCantidadRestante()))
            .ForMember(d => d.Nombre, x => x.MapFrom(src => src.GetNombrePartida()))
            .ReverseMap();

        CreateMap<PartidasAddDto, Partidas>()
            .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.Producto))
            .ForMember(dest => dest.Producto, opt => opt.Ignore())
            .ForMember(dest => dest.ProveedorId, opt => opt.MapFrom(src => src.Proveedor))
            .ForMember(dest => dest.Proveedor, opt => opt.Ignore())
            .ForMember(dest => dest.TipoActivoId, opt => opt.MapFrom(src => src.TipoActivo))
            .ForMember(dest => dest.TipoActivo, opt => opt.Ignore());


    }
}