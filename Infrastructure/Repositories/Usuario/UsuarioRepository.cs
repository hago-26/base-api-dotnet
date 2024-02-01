using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;
public class UsuarioRepository : GenericRepository<Usuario>//,IUsuarioRepository
{    
    public UsuarioRepository(BaseContext context) : base(context)
    {
        
    }

    // DESCOMENTAR AL IMPLEMENTAR AUTENTICACION POR JWT

    // public async Task<Usuario> GetByRefreshTokenAsync(string refreshToken)
    // {
    //     return await _context.Usuarios
    //                 .Include(u => u.Roles)
    //                 .Include(u => u.RefreshTokens)
    //                 .FirstOrDefaultAsync(u=>u.RefreshTokens.Any(rt=>rt.Token == refreshToken));
    // }

    // public async Task<Usuario> GetUsuarioByUsernameAsync(string username)
    // {
    //     return await _context.Usuarios
    //                 .Include(u => u.Roles)
    //                 .Include(u => u.RefreshTokens)
    //                 .FirstOrDefaultAsync(u => u.Username == username);
    // }

    


}