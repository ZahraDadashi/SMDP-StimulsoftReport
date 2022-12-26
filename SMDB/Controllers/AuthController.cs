using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SMDP.SMDPModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using SMDP;
using SMDP.Repository;
using SMDP.SMDPModels;
using SMDP.Service;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SMDP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static Userr user = new Userr();
        private readonly IConfiguration _configuration;
        private LogSingleton _logger;
        private readonly UserRepository _smdps;
        private ValidationService _validationService;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = LogSingleton.Instance;
            _smdps = new UserRepository(new SMDPModels.SmdpContext());
            _validationService = new ValidationService();
           
        }

        [HttpPost("register")]       
        public async Task<ActionResult<Userr>> Register(UserDto request)
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            string method = Request.Method.ToString();
           
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                user.UserName = request.UserName;
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                User usr = new User();
                {
                    usr.UserName = user.UserName;
                    usr.PasswordHash = user.PasswordHash;
                    usr.PasswordSalt = user.PasswordSalt;
                }

           
            _logger.WriteRequest(userAgent);
            _logger.WriteKind(method);
            _smdps.Register(usr);
            return Ok(user);                                                                      
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
          
                string userAgent = Request.Headers["User-Agent"].ToString();
                string method = Request.Method.ToString();

                Userr userlogin = new Userr();
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userlogin.UserName = request.UserName;
                userlogin.PasswordHash = passwordHash;
                userlogin.PasswordSalt = passwordSalt;

                var usertable = _smdps.Login(userlogin);

                if (usertable == null)
                {
                    return BadRequest("User not found.");
                }


                if (!VerifyPasswordHash(request.Password, usertable.PasswordHash, usertable.PasswordSalt))
                {
                    return BadRequest("Wrong password.");
                }


                string token = CreateToken(userlogin);
                var myTokenObject = new {token};
                var json = JsonConvert.SerializeObject(myTokenObject);
                _logger.WriteRequest(userAgent);
                _logger.WriteKind(method);
                return Ok(json);
                          
        }

        private string CreateToken(Userr user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
            };
                      
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,               
                expires: DateTime.UtcNow.AddDays(1),
                issuer : _configuration.GetSection("AppSettings").GetSection("Issuer").Value,
                audience:_configuration.GetSection("AppSettings").GetSection("Audience").Value,
                signingCredentials: cred);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
   
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }

        private bool  VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512(passwordSalt) )
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash); 
            }
        }

    }
}