using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileupload.Controllers.Api.v1
{
    /// <summary>
    /// 测试v1
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(GroupName = "测试类")]
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Post
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Post
        ///     {
        ///        "id": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public string Post(int Id)
        {
            return $"v1您输入的id是{Id}";
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        public string Get(int Id)
        {
            return $"v1获取到您输入的Id是{Id}";
        }
    }
}