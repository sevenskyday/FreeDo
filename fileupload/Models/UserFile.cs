using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace fileupload.Models
{
    /// <summary>
    /// 文件
    /// </summary>
    public class ImageFile
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 长度
        /// </summary>
        public long Length { get; set; }
        /// <summary>
        /// 文件格式
        /// </summary>
        public string Extension { get; set; }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 文件允许的格式
        /// </summary>
        private readonly static string[] Filters = { ".jpg", ".png", ".bmp" };
        /// <summary>
        /// 是否为允许内容
        /// </summary>
        public bool IsValid => !string.IsNullOrEmpty(Extension) && Filters.Contains(Extension);
        /// <summary>
        /// 私有
        /// </summary>
        private IFormFile file;
        /// <summary>
        /// 文件
        /// </summary>
        public IFormFile File
        {
            get { return file; }
            set
            {
                if (value != null)
                {
                    this.file = value;

                    this.FileType = this.file.ContentType;
                    this.Length = this.file.Length;
                    this.Extension = this.file.FileName.Substring(file.FileName.LastIndexOf('.'));
                    if (string.IsNullOrEmpty(this.FileName))
                        this.FileName = this.FileName;
                }
            }
        }
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="destinationDir"></param>
        /// <returns></returns>
        public async Task<string> SaveAs(string destinationDir = null)
        {
            if (this.file == null)
                throw new ArgumentNullException("没有需要保存的文件");

            if (destinationDir != null)
                Directory.CreateDirectory(destinationDir);

            var newName = DateTime.Now.Ticks;
            var newFile = Path.Combine(destinationDir ?? "", $"{newName}{this.Extension}");
            using (FileStream fs = new FileStream(newFile, FileMode.CreateNew))
            {
                await this.file.CopyToAsync(fs);
                fs.Flush();
            }

            return newFile;
        }
        
    }

  
}
