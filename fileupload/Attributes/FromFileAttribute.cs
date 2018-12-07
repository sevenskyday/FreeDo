using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fileupload.Attributes
{
    /// <summary>
    /// 过滤获取文件
    /// </summary>
    public class FromFileAttribute : Attribute, IBindingSourceMetadata
    {
       /// <summary>
       /// 绑定资源类型
       /// </summary>
        public BindingSource BindingSource => BindingSource.FormFile;
    }
}
