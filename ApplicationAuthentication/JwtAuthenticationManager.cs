using ApplicationAuthentication.Abstraction;
using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAuthentication
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly string _key = default;
        public IRepository<Account> _accountRepo = default;
        public JwtAuthenticationManager(string key)
        {
            _key = key;
        }

        public async Task<Tuple<string, int>> AuthenticateAsync(UserAuthDto data)
        {
            var account = (await _accountRepo.ReadAsync()).FirstOrDefault(o => o.EmailAddress == data.Email && o.Password == data.Password);
            if (account == null) { return null; }
            if (data.Email == "s.minashvili@mail.ru" && data.Password == "Vapa)4)5@003")
            {
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()

                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,data.Email)
                }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new Tuple<string, int>("admin", account.Id);
            }
            else
            {
                var tokenKey = Encoding.ASCII.GetBytes(_key);
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()

                {
                    Subject = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email,data.Email)
                }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return new Tuple<string, int>(tokenHandler.WriteToken(token), account.Id);
            }
        }

        public void SetAccountRepo(IRepository<Account> accountRepo)
        {
            _accountRepo = accountRepo;
        }
    }
}
