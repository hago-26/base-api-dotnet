using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PartidasRepository : GenericRepository<Partidas>, IPartidasRepository
{
    public PartidasRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Partidas> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Partidas>()
                                .CountAsync();
    
        var registros = await _context.Set<Partidas>()
                        .Include(x => x.Activos)
                        .Include(x => x.Producto)
                        .Include(x => x.TipoActivo)
                        .Include(x => x.Proveedor)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Partidas> GetByIdAsync(int id)
    {
        return await _context.Set<Partidas>()
                        .Include(x => x.Activos)
                        .Include(x => x.Producto)
                        .Include(x => x.TipoActivo)
                        .Include(x => x.Proveedor)            
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}