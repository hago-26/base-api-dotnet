using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository
{
    public ProveedorRepository(BaseContext context) : base(context)
    {

    }

        public override async Task<(int totalRegistros, IEnumerable<Proveedor> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Proveedor>()
                                .CountAsync();
    
        var registros = await _context.Set<Proveedor>()
                        .Include(x => x.Activos)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Proveedor> GetByIdAsync(int id)
    {
        return await _context.Set<Proveedor>()
            .Include(x => x.Activos)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}