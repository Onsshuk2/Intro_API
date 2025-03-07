using Microsoft.AspNetCore.Mvc;
using Intro_API.BLL.DTOs.Account;
using Intro_API.BLL.Services.Account;

namespace Intro_API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : Controller
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto dto)
        {
            var result = await _accountService.LoginAsync(dto);

            if (result == null)
                return BadRequest("Incorrect userName or password");

            return Ok(result);
        }
    }
