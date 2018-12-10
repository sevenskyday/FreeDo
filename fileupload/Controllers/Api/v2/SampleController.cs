using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileupload.Controllers.Api.v2
{
    /// <summary>
    /// 测试v2
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "测试类")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(int Id)
        {
            return $"v2您输入的id是{Id}";
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Get(int Id)
        {
            return $"v2获取到您输入的Id是{Id}";
        }
    }
}