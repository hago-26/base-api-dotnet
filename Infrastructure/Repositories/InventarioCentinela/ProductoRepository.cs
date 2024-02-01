using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
{
    public ProductoRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Producto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Producto>()
                                .CountAsync();
    
        var registros = await _context.Set<Producto>()
                        .Include(x => x.Activos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Producto> GetByIdAsync(int id)
    {
        return await _context.Set<Producto>()
            .Include(x => x.Activos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}