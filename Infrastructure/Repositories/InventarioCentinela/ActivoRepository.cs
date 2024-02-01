using System.Linq.Expressions;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ActivoRepository : GenericRepository<Activo>, IActivoRepository
{
    public ActivoRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Activo> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Activo>()
                                .CountAsync();
    
        var registros = await _context.Set<Activo>()
                        .Include(x => x.Partida)
                        .Include(x => x.Producto)
                        .Include(x => x.TipoActivo)
                        .Include(x => x.Proveedor)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Activo> GetByIdAsync(int id)
    {
        return await _context.Set<Activo>()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<(int totalRegistros, IEnumerable<Activo> registros)> FindAsyncPaginated(Expression<Func<Activo, bool>> expression, int pageIndex, int pageSize)
    {
        var registros = await _context.Set<Activo>()
                        .Include(x => x.Partida)
                        .Include(x => x.Producto)
                        .Include(x => x.TipoActivo)
                        .Include(x => x.Proveedor)
                        .Where(expression)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();

        return (registros.Count, registros);
    }
}