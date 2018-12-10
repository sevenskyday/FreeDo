using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using fileupload.Fliters;
using fileupload.Formatters;
using fileupload.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
        private static string[] docs = new[] { "默认版本", "文件类", "测试类" };
        /// <summary>
        /// Api版本提者信息
        /// </summary>
        private IApiVersionDescriptionProvider provider;
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
                //option.GroupNameFormat = "'v'VVV";
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
            services.AddSwaggerGen(options =>
            {
                //foreach (var doc in docs) options.SwaggerDoc(doc, new Info
                //{
                //    Version = $"{doc}",
                //    Title = $"{doc}_API文档",
                //    Description = $"{doc}",
                //    TermsOfService = "none",
                //    //Extensions = new Dictionary<string, object> { { "扩展1", "扩展1内容" }, { "扩展2", "扩展2内容" }},
                //    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                //    {
                //        Name = "sevenskyday",
                //        Email = "295jj@163.com",
                //        Url = "http://github.com/sevenskyday"
                //    },
                //    License = new License
                //    {
                //        Name = "许可证名字 sevenskyday",
                //        Url = "http://github.com/sevenskyday"
                //    }
                //});
                foreach (var ver in provider.ApiVersionDescriptions) options.SwaggerDoc(ver.GroupName, new Info
                {
                    Version = $"{ver.GroupName}",
                    Title = $"{ver.GroupName}_API文档",
                    Description = $"{ver.GroupName}",
                    TermsOfService = "none",
                    //Extensions = new Dictionary<string, object> { { "扩展1", "扩展1内容" }, { "扩展2", "扩展2内容" }},
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
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
                    var ver = description.GroupName;
                    return ver == docName;
                    //description.TryGetMethodInfo(out MethodInfo mi);
                    //var attr = mi.DeclaringType.GetCustomAttribute<ApiExplorerSettingsAttribute>();
                    //if (attr != null)
                    //{
                    //    return attr.GroupName == docName;
                    //}
                    //else
                    //{
                    //    return docName == "默认版本";
                    //}
                });
                // This call remove version from parameter, without it we will have version as parameter 
                // for all endpoints in swagger UI
                //options.OperationFilter<RemoveVersionFromParameter>();

                //// This make replacement of v{version:apiVersion} to real version of corresponding swagger doc.
                //options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

                // This on used to exclude endpoint mapped to not specified in swagger version.
                // In this particular example we exclude 'GET /api/v2/Values/otherget/three' endpoint,
                // because it was mapped to v3 with attribute: MapToApiVersion("3")
                //options.DocInclusionPredicate((version, desc) =>
                //{
                //   desc.TryGetMethodInfo(out MethodInfo mi);
                //    var versions = mi.DeclaringType.GetCustomAttribute<ApiVersionAttribute>().Versions;
                //    var maps = mi.DeclaringType.GetCustomAttributes<MapToApiVersionAttribute>().SelectMany(attr => attr.Versions).ToArray();

                //    return versions.Any(v => $"v{v.ToString()}" == version) && (maps.Length == 0 || maps.Any(v => $"v{v.ToString()}" == version));
                //});


                // options.OperationFilter<>();
                //options.CustomSchemaIds(d => d.FullName);
                //options.IncludeXmlComments("fileupload.xml", true);
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
            #region mvcoptions
            services.AddMvc(options =>
            {
                options.InputFormatters.Insert(0, new VcardInputFormatter());
                options.OutputFormatters.Insert(0, new VcardOutputFormatter());
            });
            #endregion

            services.AddSingleton<IContactRepository, ContactRepository>();
        }
        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                   .UseSwaggerUI(options =>
                   {
                       options.DocumentTitle = "测试文档";
                       foreach (var item in provider.ApiVersionDescriptions)
                           options.SwaggerEndpoint($"/swagger/{item.GroupName}/swagger.json", item.GroupName);
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
