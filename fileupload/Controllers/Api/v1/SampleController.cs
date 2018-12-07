using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileupload.Controllers.Api.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("v1")]
    public class SampleController : ControllerBase
    {
        /// <summary>
        /// Post
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string Post(int Id)
        {
            return $"v1您输入的id是{Id}";
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string Get(int Id)
        {
            return $"v1获取到您输入的Id是{Id}";
        }
    }
}