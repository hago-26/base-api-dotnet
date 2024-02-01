

namespace Core.Entities;

public class UsuariosRoles
{
    public int UsuarioId { get; set; }
    public Usuario Usuario { get; set; }
    public int RolId { get; set; }
    public Roles Rol { get; set; }

    
}