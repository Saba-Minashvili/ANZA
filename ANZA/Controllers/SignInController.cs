using ApplicationAuthentication.Abstraction;
using ApplicationDomainCore.Repositories.Abstraction;
using ApplicationDomainDtos.Dtos;
using ApplicationDomainModels.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ANZA.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IRepository<Account> _accountRepo = default;
        private readonly IJwtAuthenticationManager _authenticationManager = default;
        public SignInController(IRepository<Account> accountRepo, IJwtAuthenticationManager authenticationManager)
        {
            _accountRepo = accountRepo;
            _authenticationManager = authenticationManager;
            _authenticationManager.SetAccountRepo(_accountRepo);
        }

        //POST: api/<SignInController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserAuthDto value)
        {
            var token = await _authenticationManager.AuthenticateAsync(value);
            if (token == null)
            {
                // returning Ok() in order to get valid response in the front
                // but still user is not authenticated
                return Ok();
            }
            else
            {
                return Ok(new { bearerToken = token.Item1, Id = token.Item2 });
            }
        }
    }
}
