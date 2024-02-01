

namespace API.Helpers;

public class Autorizacion
{
    public enum Roles
    {
        Administrador,
        Gerente,
        Usuario
    }

    public const Roles rol_predeterminado = Roles.Usuario;
}