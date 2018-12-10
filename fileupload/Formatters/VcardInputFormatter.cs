using fileupload.Models;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileupload.Formatters
{

    #region classdef
    /// <summary>
    /// 
    /// </summary>
    public class VcardInputFormatter : TextInputFormatter
    #endregion
    {
        #region ctor
        /// <summary>
        /// 
        /// </summary>
        public VcardInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/vcard"));

            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        #endregion

        #region canreadtype
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected override bool CanReadType(Type type)
        {
            if (type == typeof(Contact))
            {
                return base.CanReadType(type);
            }
            return false;
        }
        #endregion

        #region readrequest
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="effectiveEncoding"></param>
        /// <returns></returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding effectiveEncoding)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (effectiveEncoding == null)
            {
                throw new ArgumentNullException(nameof(effectiveEncoding));
            }

            var request = context.HttpContext.Request;

            using (var reader = new StreamReader(request.Body, effectiveEncoding))
            {
                try
                {
                    await ReadLineAsync("BEGIN:VCARD", reader, context);
                    await ReadLineAsync("VERSION:2.1", reader, context);

                    var nameLine = await ReadLineAsync("N:", reader, context);
                    var split = nameLine.Split(";".ToCharArray());
                    var contact = new Contact() { LastName = split[0].Substring(2), FirstName = split[1] };

                    await ReadLineAsync("FN:", reader, context);

                    var idLine = await ReadLineAsync("UID:", reader, context);
                    contact.ID = idLine.Substring(4);

                    await ReadLineAsync("END:VCARD", reader, context);

                    return await InputFormatterResult.SuccessAsync(contact);
                }
                catch
                {
                    return await InputFormatterResult.FailureAsync();
                }
            }
        }

        private async Task<string> ReadLineAsync(string expectedText, StreamReader reader, InputFormatterContext context)
        {
            var line = await reader.ReadLineAsync();
            if (!line.StartsWith(expectedText))
            {
                var errorMessage = $"Looked for '{expectedText}' and got '{line}'";
                context.ModelState.TryAddModelError(context.ModelName, errorMessage);
                throw new Exception(errorMessage);
            }
            return line;
        }
        #endregion
    }
}
