using ComputerTechnicianBackend.API.Contracts.IncomingOutgoing;
using ComputerTechnicianBackend.Data.Domain.Models;
using ComputerTechnicianBackend.Data.Services.Abstraction;
using ComputerTechnicianBackend.Data.EF.SQL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ComputerTechnicianBackend.Data.Services
{
    public interface IUserService : IBaseService<User> 
    {
        Task<bool> ExistAsync(UserDTO user);
        Task<bool> LoginAsync(UserDTO user);
        string CreateToken(User user, string role);
    }

    public class UserService : BaseService<User> , IUserService
    {
        private readonly ComputerTechnicianDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserService(ComputerTechnicianDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public async Task<bool> ExistAsync(UserDTO userDTO)
        {
            if (!await dbContext.Users.AnyAsync(entity =>
                entity.Email == userDTO.Email))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> LoginAsync(UserDTO userDTO)
        {
            var user = await dbContext.Users.Where(entity => entity.Email == userDTO.Email).FirstOrDefaultAsync();

            if (user.Password != userDTO.Password)
            {
                return false;
            }

            return true;
        }

        public string CreateToken(User user, string role)
        {
            var signingCredentials = GetSigningCredentials();
            var Claims = GetClaims(user, role);
            var tokenOptions = GenerateTokenOptions(signingCredentials, Claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = configuration.GetSection("JwtSettings").GetSection("key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key + key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private List<Claim> GetClaims(User user, string role)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var binaryRole = ToBinary(ConvertToByteArray(role, Encoding.ASCII));

            claims.Add(new Claim(ClaimTypes.Role, binaryRole));
            
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = configuration.GetSection("jwtSettings");
            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings.GetSection("validIssuer").Value,
                audience: jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings.GetSection("minutesExpires").Value)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }

        private static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        private static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}
