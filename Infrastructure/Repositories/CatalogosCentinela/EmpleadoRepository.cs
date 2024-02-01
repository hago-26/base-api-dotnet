using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleadoRepository
{
    public EmpleadoRepository(BaseContext context) : base(context)
    {

    }

    public override async Task<(int totalRegistros, IEnumerable<Empleado> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _context.Set<Empleado>()
                                .CountAsync();
    
        var registros = await _context.Set<Empleado>()
                        .Include(x => x.Dependencia)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize)
                        .ToListAsync();
        return (totalRegistros, registros);
    }
    
    public override async Task<Empleado> GetByIdAsync(int id)
    {
        return await _context.Set<Empleado>()
            .Include(x => x.Dependencia)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

}