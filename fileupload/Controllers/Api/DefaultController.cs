using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileupload.Controllers.Api
{
    /// <summary>
    /// 测试
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "测试类")]
    public class DefaultController : ControllerBase
    {
        // GET api/authors/version
        [HttpGet]
        public string Version()
        {
            return "Version 1.0.0";
        }
        [HttpGet]
        public IActionResult Get() => Ok();
        [HttpPost]
        public IActionResult Post() => BadRequest();
        [HttpGet]
        public IActionResult GetResult(int id) => Ok(id);
        [HttpPost]
        public IActionResult PostResult(int id) => BadRequest(id);
    }
}