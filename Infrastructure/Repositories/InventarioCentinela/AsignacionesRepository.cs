using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AsignacionesRepository : GenericRepository<Asignaciones>, IAsignacionesRepository
{
    public AsignacionesRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Asignaciones> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Asignaciones>()
                                .CountAsync();
    
        var registros = await _context.Set<Asignaciones>()
                        .Include(x => x.Activo)
                        .Include(x => x.Activo.Producto)
                        .Include(x => x.Resguardante)
                        .Include(x => x.Municipio)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Asignaciones> GetByIdAsync(int id)
    {
        return await _context.Set<Asignaciones>()
                        .Include(x => x.Activo)
                        .Include(x => x.Activo.Producto)
                        .Include(x => x.Resguardante)
                        .Include(x => x.Municipio)
                        .FirstOrDefaultAsync(x => x.Id == id);
    }
    
}