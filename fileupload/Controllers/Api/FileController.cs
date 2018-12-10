using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using fileupload.Attributes;
using fileupload.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fileupload.Controllers.Api
{
    /// <summary>
    /// 文件服务
    /// </summary>
    [Route("api/[controller]/[action]"), ApiExplorerSettings(GroupName = "文件类")]
    [ApiController]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <remarks>
        /// <code>
        /// 输出参数：new { code = 0, message = "成功", url = newFile }
        /// </code>
        /// </remarks>
        /// <param name="file">接收到的文件<see langword="11" cref="UserFile"/></param>
        /// <returns>图片地址</returns>
        /// <response code="0">返回图片地址</response>
        /// <response code="500">文件为空</response>  
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>     
        /// <example>
        /// <code>PostImagess</code>
        /// </example>
        [HttpPost]
        public async Task<IActionResult> PostImage([FromFile]ImageFile file)
        {
            if (file == null || !file.IsValid)
                return new JsonResult(new { code = 500, message = "不允许上传的文件类型" });
            string newFile = string.Empty;
            if (file != null)
                newFile = await file.SaveAs("E:/github/files/images");

            return new JsonResult(new { code = 0, message = "成功", url = newFile });
        }
    }
}