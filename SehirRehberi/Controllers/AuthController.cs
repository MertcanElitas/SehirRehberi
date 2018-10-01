using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sehir.Common.Dto;
using Sehir.Common.Helpers;
using Sehir.Core.Services;

namespace SehirRehberi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody]RegisterDto registerDto)
        {
            if (await Services.AuthRepository.UserExist(registerDto.Username))
            {
                ModelState.AddModelError("", "Bu Kullanıcı Adı Kullanılmakta");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }




           var registeruser= Services.AuthRepository.Register(registerDto);
            return StatusCode(201,registeruser);
        }

        public async Task<ActionResult> Login([FromBody]RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

           var x=Services.AuthRepository.Login(registerDto.Username, registerDto.Password);

            if (x==null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();//Token işlemini yapıcak tokenla ugraşacak olan .net sınıfı;

            var key =Encoding.ASCII.GetBytes(HttpHelper._configuration.GetSection("AppSettings:Token").Value);//AppSettings deki key değerini okuduk.

            //Token içerisine Konulucak nesneneler

            var tokendescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier,x.Id.ToString()),
                    //new Claim(ClaimTypes.Name,x.Username)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials=new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.EcdsaSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokendescriptor);
            var tokenString = tokenHandler.WriteToken(token);
;
            return Ok(x);

        }


    }
}