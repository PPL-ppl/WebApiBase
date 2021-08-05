using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApiBase.Common;
using WebApiBase.DTO;

namespace WebApiBase.Controllers
{
    public class TokenController : BaseController
    {
        [HttpPost]
        public string Login(LoginDTO loginDto)
        {
            //创建用户名密码

            //创建JWT
            //header
            string signingAlgorithm = SecurityAlgorithms.HmacSha256;
            //payload
            var claims = new[]
            {
                //sub
                new Claim(JwtRegisteredClaimNames.Sub, "faker_user_id")
            };

            //signiture
            var secretByte =
                Encoding.UTF8.GetBytes(AppSettings.app(new string[] { "AppSettings", "JwtSetting", "SecretKey" }));
            var sigIngKey = new SymmetricSecurityKey(secretByte);
            var signingCredentials = new SigningCredentials(sigIngKey, signingAlgorithm);

            var token = new JwtSecurityToken(
                issuer: AppSettings.app(new string[] { "AppSettings", "JwtSetting", "issuer" }),
                audience: AppSettings.app(new string[] { "AppSettings", "JwtSetting", "audience" }),
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials);

            string writeToken = new JwtSecurityTokenHandler().WriteToken(token);
            //返回数据
            return JsonHelper.toJson(writeToken);

            /*string jwtStr = string.Empty;
            bool suc = false;

            if (role != null)
            {
                // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
                TokenModel tokenModel = new TokenModel {Uid = "abcde", Role = role};
                jwtStr = JwtHelper.IssueJwt(tokenModel); //登录，获取到一定规则的 Token 令牌
                suc = true;
            }
            else
            {
                jwtStr = "login fail!!!";
            }

            return Ok(new
            {
                success = suc,
                token = jwtStr
            });*/
        }


        [HttpGet]
        public void hello()
        {
            Log4NetLog.WriteInfo("HELLO", true);
            Console.WriteLine("hello");
        }
    }
}