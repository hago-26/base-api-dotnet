using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class TipoActivoRepository : GenericRepository<TipoActivo>, ITipoActivoRepository
{
    public TipoActivoRepository(BaseContext context) : base(context)
    {

    }

        public override async Task<(int totalRegistros, IEnumerable<TipoActivo> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<TipoActivo>()
                                .CountAsync();
    
        var registros = await _context.Set<TipoActivo>()
                        .Include(x => x.Activos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<TipoActivo> GetByIdAsync(int id)
    {
        return await _context.Set<TipoActivo>()
            .Include(x => x.Activos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }


}