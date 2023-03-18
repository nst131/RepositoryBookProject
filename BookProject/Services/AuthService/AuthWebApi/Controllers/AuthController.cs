using Application.Exceptions;
using Application.Registration;
using Application.User.Login;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace AuthWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginHandler loginHandler;
        private readonly IRegistrationHandler registrationHandler;
        private readonly IMapper mapper;

        public AuthController(ILoginHandler loginHandler, IRegistrationHandler registrationHandler, IMapper mapper)
        {
            this.loginHandler = loginHandler;
            this.registrationHandler = registrationHandler;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<ActionResult<string>> LoginAsync([FromBody] LoginQuery request)
        {
            if (request is null)
                throw new RestException(HttpStatusCode.BadRequest, $"{nameof(LoginQuery)} is null");

            var user = await loginHandler.Login(request);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(user)} is null");

            var jwtToken = $"{JwtBearerDefaults.AuthenticationScheme}" + " " + $"{user.Token}";

            return new JsonResult(new { Response = "Success", Token = jwtToken });
        }

        [AllowAnonymous]
        [HttpPost("Registration")]
        public async Task<ActionResult<string>> RegistrationUserAsync([FromBody] RegistrationUserQuery request)
        {
            if (request is null)
                throw new RestException(HttpStatusCode.BadRequest, $"{nameof(RegistrationUserQuery)} is null");

            var registrationQuery = mapper.Map<RegistrationQuery>(request);

            var user = await registrationHandler.Registration(registrationQuery);

            if (user is null)
                throw new RestException(HttpStatusCode.Unauthorized, $"{nameof(user)} is null");

            var jwtToken = $"{JwtBearerDefaults.AuthenticationScheme}" + " " + $"{user.Token}";

            return new JsonResult(new { Response = "Success", Token = jwtToken });
        }
    }
}
