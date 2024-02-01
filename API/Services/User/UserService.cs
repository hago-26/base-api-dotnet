using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using API.DTOs;
using API.Helpers;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services;

public class UserService : IUserService
{
    private readonly JWT _jwt;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher<Usuario> _passwordHasher;

    public UserService(IOptions<JWT> jwt, IUnitOfWork unitOfWork, IPasswordHasher<Usuario> passwordHasher)
    {
        _jwt = jwt.Value;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
    }

                // DESCOMENTAR AL IMPLEMENTAR AUTENTICACION POR JWT

    // public async Task<string> RegisterUserAsync(RegisterDTO model)
    // {
    //     var usuario = new Usuario
    //     {
    //         Nombres = model.Nombre,
    //         ApellidoMaterno = model.ApellidoMaterno,
    //         ApellidoPaterno = model.ApellidoPaterno,
    //         Email = model.Email,
    //         Username = model.Username,
    //     };

    //     usuario.Password = _passwordHasher.HashPassword(usuario, model.Password);
    //     var usuarioExiste = _unitOfWork.UsuarioRepository
    //                         .FindAsync(x => x.Username.ToLower() == model.Username.ToLower())
    //                         .FirstOrDefault();
        
    //     if (usuarioExiste == null)
    //     {
    //         var rolPredeterminado = _unitOfWork.RolRepository
    //                                 .FindAsync(x => x.Nombre == Autorizacion.rol_predeterminado.ToString())
    //                                 .First();

    //         try
    //         {
    //             usuario.Roles.Add(rolPredeterminado);
    //             _unitOfWork.UsuarioRepository.Add(usuario);
    //             await _unitOfWork.CompleteAsync();

    //             return $"El Usuario {usuario.Username} se ha registrado correctamente";
    //         }
    //         catch (Exception e)
    //         {
    //             return $"Error: {e.Message}";
    //         }
    //     }
    //     return $"El Usuario {usuario.Username} ya existe";
    // }

    // public async Task<DatosUsuarioDto> GetTokenAsync(LoginDto model)
    // {
    //     var usuario = await _unitOfWork.UsuarioRepository
    //                     .GetUsuarioByUsernameAsync(model.Username);

    //     if (usuario == null)
    //     {
    //         return new DatosUsuarioDto
    //         {
    //             Mensaje = $"El Usuario {model.Username} no existe",
    //             Autenticado = false
    //         };
    //     }

    //     var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

    //     if (resultado == PasswordVerificationResult.Failed)
    //     {
    //         return new DatosUsuarioDto
    //         {
    //             Mensaje = $"La contraseña es incorrecta",
    //             Autenticado = false
    //         };
    //     }

    //     var roles = usuario.Roles.Select(r => r.Nombre).ToList();

    //     JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);

    //     DatosUsuarioDto datosUsuario = new DatosUsuarioDto
    //     {
    //         Mensaje = $"Bienvenido {usuario.Username}",
    //         Autenticado = true,
    //         Username = usuario.Username,
    //         Email = usuario.Email,
    //         Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
    //         Roles = roles
    //     };

    //     if (usuario.RefreshTokens.Any(a=>a.IsActive))
    //     {
    //         var activeRefreshToken = usuario.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
    //         datosUsuario.RefreshToken = activeRefreshToken.Token;
    //         datosUsuario.ExpiracionRefreshToken = activeRefreshToken.Expires;
    //     }
    //     else
    //     {
    //         var refreshToken = CreateRefreshToken();
    //         datosUsuario.RefreshToken = refreshToken.Token;
    //         datosUsuario.ExpiracionRefreshToken = refreshToken.Expires;
    //         usuario.RefreshTokens.Add(refreshToken);
    //         _unitOfWork.UsuarioRepository.Update(usuario);
    //         await _unitOfWork.CompleteAsync();
    //     }
    //     return datosUsuario;

    // }

    // private JwtSecurityToken CreateJwtToken(Usuario usuario)
    // {
    //     var roles = usuario.Roles;
    //     var rolClaims = new List<Claim>();

    //     foreach (var rol in roles)
    //     {
    //         rolClaims.Add(new Claim("roles", rol.Nombre));
    //     }

    //     var claims = new[]
    //     {
    //         new Claim(JwtRegisteredClaimNames.Sub, usuario.Username),
    //         new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
    //         new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    //         new Claim("uid", usuario.Id.ToString()),
    //     }.Union(rolClaims);

    //     var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.key));
    //     var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
    //     var jetSecurityToken = new JwtSecurityToken(
    //         issuer: _jwt.Issuer,
    //         audience: _jwt.Audience,
    //         claims: claims,
    //         expires: DateTime.UtcNow.AddMinutes(_jwt.ExpirationInMinutes),
    //         signingCredentials: signingCredentials
    //     );

    //     return jetSecurityToken;


    // }

    // public async Task<string> AddRolesAsync(AddRolDto model)
    // {
    //     var usuario = await _unitOfWork.UsuarioRepository
    //                     .GetUsuarioByUsernameAsync(model.Username);

    //     if (usuario == null)
    //         return $"El Usuario {model.Username} no existe";
        
    //     var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Password, model.Password);

    //     if (resultado == PasswordVerificationResult.Failed)
    //         return $"La contraseña es incorrecta";

    //     var rolExiste = _unitOfWork.RolRepository
    //                 .FindAsync(x => x.Nombre.ToLower() == model.Rol.ToLower())
    //                 .FirstOrDefault();
        
    //     if (rolExiste == null)
    //         return $"El Rol {model.Rol} no existe";

    //     var usuarioTieneRol = usuario.Roles
    //                             .Any(r => r.Id == rolExiste.Id);
        
    //     if (usuarioTieneRol)
    //         return $"El Usuario {model.Username} ya tiene el Rol {model.Rol}";

    //     usuario.Roles.Add(rolExiste);
    //     _unitOfWork.UsuarioRepository.Update(usuario);
    //     await _unitOfWork.CompleteAsync();

    //     return $"Rol {model.Rol} agregado al Usuario {model.Username} correctamente";
    // }

    // private RefreshToken CreateRefreshToken()
    // {
    //     var randomNumber = new byte[32];
    //     using (var generator = RandomNumberGenerator.Create())
    //     {
    //         generator.GetBytes(randomNumber);
    //         return new RefreshToken
    //         {
    //             Token = Convert.ToBase64String(randomNumber),
    //             Expires = DateTime.UtcNow.AddDays(10),
    //             Created = DateTime.UtcNow

    //         };
    //     }
    // }

    // public async Task<DatosUsuarioDto> RefreshTokenAsync(string refreshToken)
    // {
    //     var datosUsuarios = new DatosUsuarioDto();

    //     var usuario =  await _unitOfWork.UsuarioRepository
    //                     .GetByRefreshTokenAsync(refreshToken);

    //     if(usuario == null)
    //     {
    //         datosUsuarios.Mensaje = "El token de refresco no existe";
    //         datosUsuarios.Autenticado = false;
    //         return datosUsuarios;
    //     }

    //     var refreshTokenExistente = usuario.RefreshTokens
    //                                 .SingleOrDefault(x => x.Token == refreshToken);
        
    //     if (!refreshTokenExistente.IsActive)
    //     {
    //         datosUsuarios.Mensaje = "El token de refresco no esta activo";
    //         datosUsuarios.Autenticado = false;
    //         return datosUsuarios;
    //     }

    //     refreshTokenExistente.Revoked = DateTime.UtcNow;
    //     var newRefreshToken = CreateRefreshToken();
    //     usuario.RefreshTokens.Add(newRefreshToken);
    //     _unitOfWork.UsuarioRepository.Update(usuario);
    //     await _unitOfWork.CompleteAsync();

    //     datosUsuarios.Autenticado = true;
    //     JwtSecurityToken jwtSecurityToken = CreateJwtToken(usuario);
    //     datosUsuarios.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    //     datosUsuarios.Email = usuario.Email;
    //     datosUsuarios.Username = usuario.Username;
    //     datosUsuarios.Roles = usuario.Roles.Select(r => r.Nombre).ToList();
    //     datosUsuarios.RefreshToken = newRefreshToken.Token;
    //     datosUsuarios.ExpiracionRefreshToken = newRefreshToken.Expires;

    //     return datosUsuarios;
    // }


    
}