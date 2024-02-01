using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class SubcentroRepository : GenericRepository<Subcentro>, ISubcentroRepository
{
    public SubcentroRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Subcentro> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Subcentro>()
                                .CountAsync();
    
        var registros = await _context.Set<Subcentro>()
                        .Include(x => x.Municipios)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Subcentro> GetByIdAsync(int id)
    {
        return await _context.Set<Subcentro>()
            .Include(x => x.Municipios)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}