using System.Text.Json.Serialization;


namespace API.DTOs;

public class DatosUsuarioDto
{
    public string Mensaje { get; set; }
    public bool Autenticado { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
    public List<string> Roles { get; set; }

    [JsonIgnore] // Evita que se serialice el refresh token
    public string RefreshToken { get; set; }
    public DateTime ExpiracionRefreshToken { get; set; }


}