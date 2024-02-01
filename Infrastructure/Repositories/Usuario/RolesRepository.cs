using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories;
public class RolesRepository : GenericRepository<Roles>, IRolRepository
{    
    public RolesRepository(BaseContext context) : base(context)
    {
        
    }
}
