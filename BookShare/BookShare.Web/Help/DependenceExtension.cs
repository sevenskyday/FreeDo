using BookShare.Service;
using BookShare.Service.BookService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading.Tasks;
using BookShare.Service.Interfaces;

namespace BookShare.Web.Help
{

    public static class DependenceExtension
    {
        public static List<Type> GetTypeOfISerice(this AssemblyName assemblyName)
        {
            return AssemblyLoadContext.Default.LoadFromAssemblyName(assemblyName).ExportedTypes.Where(b => b.GetInterfaces().Contains(typeof(IBookService)) && !b.IsAbstract).ToList();
        }

        public static void AddService(this IServiceCollection services)
        {
            var defaultAssemblyNames = DependencyContext.Default.GetDefaultAssemblyNames().Where(a => a.FullName.Contains("BookShare.Service")).ToList();

            var assemblies = defaultAssemblyNames.SelectMany(a => a.GetTypeOfISerice()).ToList();

            assemblies.ForEach(assembliy =>
            {
                services.AddScoped(assembliy);
            });
        }
    }
}
