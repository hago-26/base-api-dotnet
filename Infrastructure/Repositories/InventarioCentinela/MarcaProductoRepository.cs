using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MarcaProductoRepository : GenericRepository<MarcaProducto>, IMarcaProductoRepository
{
    public MarcaProductoRepository(BaseContext context) : base(context)
    {

    }

        public override async Task<(int totalRegistros, IEnumerable<MarcaProducto> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<MarcaProducto>()
                                .CountAsync();
    
        var registros = await _context.Set<MarcaProducto>()
                        .Include(x => x.Productos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<MarcaProducto> GetByIdAsync(int id)
    {
        return await _context.Set<MarcaProducto>()
            .Include(x => x.Productos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}