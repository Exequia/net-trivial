using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trivial.Models;
using trivial.Services.interfaces;

namespace trivial.Services
{
    public class UserService : IUserService
    {
        //public const string EMPLOYEE_ID = "employeeId";
        //public const string MANAGER_ROLE = "Responsable";
        //public const string IS_PM = "isPM";
        //private readonly AppSettings _appSettings;

        //public UserService(IOptions<AppSettings> appSettings, IAltrixContextService altrixContextService)
        //{
        //    _appSettings = appSettings.Value;
        //    AltrixContext.Current = altrixContextService.GetCurrentContext();
        //}

        //public User Authenticate(string username, string password)
        //{
        //    Usuarios altrixUser = UsuariosService.Instance.Login(username, password);

        //    if (altrixUser == null)
        //        return null;

        //    // Authentication successful so generate jwt token
        //    User user = new User(altrixUser);
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

        //    try
        //    {
        //        TList<Empleados> empleados = GetEmpleadosByUserId(user.Username);
        //        if (empleados.Count > 0)
        //        {
        //            Empleados empleado = empleados.First();
        //            user.EmployeeId = empleado.IdEmpleado;
        //            user.isPM = CheckRole(empleados.First().IdUsuario, MANAGER_ROLE);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Debug("Error recuperando empleados: {0}", ex.Message);
        //        user.EmployeeId = String.Empty;
        //    }

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //            new Claim(ClaimTypes.Name, user.Username),
        //            new Claim(ClaimTypes.Sid, user.Id.ToString()),
        //            new Claim(EMPLOYEE_ID, user.EmployeeId),
        //            new Claim(IS_PM, user.isPM.ToString())
        //        }),
        //        Expires = DateTime.UtcNow.AddDays(7),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    user.Token = tokenHandler.WriteToken(token);

        //    // Remove password before returning
        //    user.Password = null;

        //    return user;
        //}

        //public long GetLoggedUserId(ClaimsPrincipal user)
        //{
        //    return long.Parse(user.FindFirst(ClaimTypes.Sid)?.Value);
        //}

        //public string GetLoggedUserIdEmpleado(ClaimsPrincipal user)
        //{
        //    return user.FindFirst(EMPLOYEE_ID)?.Value;
        //}

        //public string GetLoggedUserName(ClaimsPrincipal user)
        //{
        //    return user.FindFirst(ClaimTypes.Name)?.Value;
        //}

        //public bool GetIfLoggedUserIsManager(ClaimsPrincipal user)
        //{
        //    return Boolean.Parse(user.FindFirst(IS_PM).Value);
        //}

        //public TList<Empleados> GetEmpleadosByUserId(string UserID)
        //{
        //    TList<Empleados> empleados = EmpleadosService.Instance.GetByIdUsuario(UserID);
        //    if (empleados == null || empleados.Count == 0) throw new Exception("notUserFound");

        //    return empleados;
        //}

        //public TList<Empleados> GetEmpleadosCurrentUser(ClaimsPrincipal user)
        //{
        //    return GetEmpleadosByUserId(GetLoggedUserName(user));
        //}

        //public DataSet SearchEmployes(string searchValue)
        //{
        //    string SQLQuery = "SELECT TOP 20 E.IdEmpleado AS 'employedId', E.Nombre + ' ' + E.Apellidos AS 'employedName' "
        //                    + " FROM Empleados E "
        //                    + " LEFT JOIN ValorCampo V ON (E.SituacionEmpleado = V.Valor AND IdCampo = (SELECT IdCampo FROM Campo WHERE Campo = 'SituacionEmpleado'))"
        //                    + " WHERE LOWER(E.Nombre) + ' ' + LOWER(E.Apellidos) LIKE LOWER('%" + searchValue + "%') AND V.es_ES = 'Activo' "
        //                    + " ORDER BY 2 ASC ";

        //    return QueryService.ExecuteQuery(SQLQuery);
        //}

        //public bool CheckRole(string userId, string roleToCheck)
        //{
        //    TList<RolUsuario> userRoles = GetLoggedUserRoles(userId);

        //    return CheckIfRoleExist(userRoles, roleToCheck);
        //}

        //public TList<RolUsuario> GetLoggedUserRoles(string idUsuario)
        //{
        //    TList<RolUsuario> userRoles = RolUsuarioService.Instance.GetByIdUsuario(idUsuario);

        //    if (userRoles.Count == 0)
        //        throw new Exception("noUserRole");

        //    return userRoles;
        //}

        //private bool CheckIfRoleExist(TList<RolUsuario> userRoles, string roleToCheck)
        //{
        //    bool exist = false;

        //    userRoles.ForEach(role =>
        //    {
        //        if (role.IdRol.Equals(roleToCheck))
        //        {
        //            exist = true;
        //        }
        //    });

        //    return exist;
        //}
        public User Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}