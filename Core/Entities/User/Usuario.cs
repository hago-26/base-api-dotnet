

namespace Core.Entities;
public class Usuario : BaseEntity
{    
    public string Nombres { get; set; }
    public string ApellidoPaterno { get; set; }
    public string ApellidoMaterno { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<Roles> Roles { get; set; } = new HashSet<Roles>();
    public ICollection<UsuariosRoles> UsuarioRoles { get; set; }

    public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();

}