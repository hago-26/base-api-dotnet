using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MunicipioRepository : GenericRepository<Municipio>, IMunicipioRepository
{
    public MunicipioRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Municipio> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Municipio>()
                                .CountAsync();
    
        var registros = await _context.Set<Municipio>()
                        .Include(x => x.Subcentro)
                        .Include(x => x.Asignaciones)
                                .ThenInclude(a => a.Activo)   
                                .ThenInclude(a => a.Producto)                     
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }

    public override async Task<Municipio> GetByIdAsync(int id)
    {
        return await _context.Set<Municipio>()
                        .Include(x => x.Subcentro)
                        .Include(x => x.Asignaciones)
                                .ThenInclude(a => a.Activo)   
                                .ThenInclude(a => a.Producto)                     
                        .FirstOrDefaultAsync(x => x.Id == id);
    }
}