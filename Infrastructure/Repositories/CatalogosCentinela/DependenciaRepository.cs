using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DependenciaRepository : GenericRepository<Dependencia>, IDependenciaRepository
{
    public DependenciaRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Dependencia> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Dependencia>()
                                .CountAsync();

        var registros = await _context.Set<Dependencia>()
                        .Include(x => x.DependenciaPadre)
                        .Include(x => x.DependenciasHijas)
                        .Include(x => x.Empleados)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }

    public override async Task<Dependencia> GetByIdAsync(int id)
    {
        return await _context.Set<Dependencia>()
            .Include(x => x.DependenciaPadre)
            .Include(x => x.DependenciasHijas)
            .Include(x => x.Empleados)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}