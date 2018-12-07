using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace fileupload
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Swagger 分类
        /// </summary>
        private static string[] docs = new[] { "默认版本", "文件类", "v1", "v2" };
        /// <summary>
        /// Api版本提者信息
        /// </summary>
        //private IApiVersionDescriptionProvider provider;
        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// 服务注册
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.ReportApiVersions = false;
                option.DefaultApiVersion = new ApiVersion(1, 0);
            })
           .AddMvcCore().AddVersionedApiExplorer(option =>
           {
               option.GroupNameFormat = "'v'VVV";
               option.AssumeDefaultVersionWhenUnspecified = true;
           });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(options =>
            {
                //foreach (var ver in provider.ApiVersionDescriptions)
                foreach (var doc in docs) options.SwaggerDoc(doc, new Info
                {
                    Version = doc,
                    Title = $"{doc}_API文档",
                    Description = $"{doc}",
                    TermsOfService = "不知道是什么意思",
                    //Extensions = new Dictionary<string, object> { { "扩展1", "扩展1内容" }, { "扩展2", "扩展2内容" }},
                    Contact = new Contact
                    {
                        Name = "sevenskyday",
                        Email = "295jj@163.com",
                        Url = "http://github.com/sevenskyday"
                    },
                    License = new License
                    {
                        Name = "许可证名字 sevenskyday",
                        Url = "http://github.com/sevenskyday"
                    }
                });


                options.DocInclusionPredicate((docName, description) =>
                {
                    description.TryGetMethodInfo(out MethodInfo mi);
                    var ver = mi.DeclaringType.GetCustomAttribute<ApiVersionAttribute>();
                    // return ver.Versions.ToString() == docName;
                    //if (ver != null)
                    //{
                    //    Console.Write(ver);
                    //    //return ver.Versions.FirstOrDefault().ToString() == docName;
                    //}
                    //else
                    //{
                    //}
                    var attr = mi.DeclaringType.GetCustomAttribute<ApiExplorerSettingsAttribute>();
                    if (attr != null)
                    {
                        return attr.GroupName == docName;
                    }
                    else
                    {
                        return docName == "默认版本";
                    }



                });
                // options.OperationFilter<>();
                options.CustomSchemaIds(d => d.FullName);
                options.IncludeXmlComments("fileupload.xml", true);
            });
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                   .UseSwaggerUI(options =>
                   {
                       options.DocumentTitle = "测试文档";
                       foreach (var item in docs)
                           options.SwaggerEndpoint($"/swagger/{item}/swagger.json", item);
                   });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
