using System;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace KinoG.BL
{
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;

        private readonly JwtFactory _jwtFactory;

        private readonly JwtIssuerOptions _jwtOptions;

        public AuthenticationService(UserManager<IdentityUser> userManager, JwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<string> GetTokenAsync(string googleToken)
        {
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(googleToken); // todo:check audience
            if (await _userManager.FindByEmailAsync(payload.Email) == null)
            {
                await _userManager.CreateAsync(
                    new IdentityUser() { Email = payload.Email, UserName = payload.Email },
                    Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8));
            }
            var result = await _userManager.FindByEmailAsync(payload.Email);

            string jwt = await Tokens.GenerateJwt(
                _jwtFactory.GenerateClaimsIdentity(result.UserName, result.Id),
                _jwtFactory,
                payload.Email,
                _jwtOptions,
                new JsonSerializerSettings { Formatting = Formatting.Indented });
            return jwt;
        }
        
    }
}
