

using Core.Entities;

namespace Core.Interfaces;
public interface IUsuarioRepository : IGenericRepository<Usuario>
{    
    Task<Usuario> GetUsuarioByUsernameAsync(string username);

    Task<Usuario> GetByRefreshTokenAsync(string refreshToken);
}