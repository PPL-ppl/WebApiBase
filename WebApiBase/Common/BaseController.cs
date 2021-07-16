using Microsoft.AspNetCore.Mvc;

namespace WebApiBase.Common
{
    /// <summary>
    /// 自定义路由模版
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : Controller
    {
    }
}