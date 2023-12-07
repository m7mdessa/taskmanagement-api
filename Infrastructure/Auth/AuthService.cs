using Application.Auth;
using Application.DTO;
using Domain.Aggregates.DeveloperAggregate;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly TaskManagementContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthService(TaskManagementContext context, IOptions<JwtSettings> jwtSettings)
        {

            _context = context;
            _jwtSettings = jwtSettings.Value;
        }

        public void Register(RegistrationRequest request)
        {
            var address = new Address(request.Street, request.City, request.State, request.Country, request.ZipCode);

            var developer =  new Developer(request.Id,request.FirstName, request.LastName, request.Email, address, request.UserName, request.Password);

            _context?.Add(developer);
            _context?.SaveChanges();
        }
        public string Login(AuthRequest request)
        {
            var login = _context.Developers.Where(d => d.UserLogins.Any(u => u.UserName == request.UserName))
            .Select(d => new
            {
               Developer = d,
               UserLogin = d.UserLogins.FirstOrDefault(u => u.UserName == request.UserName)

            })
            .FirstOrDefault();

            if (login != null)
            {


                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

                var signinCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                var userLogin = login.UserLogin;

                var claims = new List<Claim> 
                {
                new Claim("RoleId", userLogin.RoleId.ToString()),
                new Claim("DeveloperId", userLogin.DeveloperId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss,_jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience)
                };

                var jwtSecurityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signinCredentials
                );

                var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return token;
            }
            else
            {
                return null;
            }
        }


        public bool IsUsernameTaken(string username)
        {
            bool isTaken = _context.Developers.Any(d => d.UserLogins.Any(u => u.UserName == username));

            return isTaken;
        }

        public bool IsEmailTaken(string email)
        {
            return _context.Developers.Any(e => e.Email == email);
        }
    }
}
