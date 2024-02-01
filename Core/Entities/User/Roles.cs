

namespace Core.Entities;
public class Roles : BaseEntity
{
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public ICollection<Usuario> Usuarios { get; set; }
    public ICollection<UsuariosRoles> UsuariosRoles { get; set; }
}