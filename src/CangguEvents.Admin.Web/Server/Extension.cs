using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace CangguEvents.Admin.Web.Server
{
    static class Extension
    {
        public static void RegisterAutomapper(this IServiceCollection service)
        {
            var autoMapperProfiles = EnumerateAllAssemblies()
                .SelectMany(an => Assembly.Load(an).GetTypes())
                .Where(p => typeof(Profile).IsAssignableFrom(p) && p.IsPublic && !p.IsAbstract)
                .Distinct()
                .Select(p => Activator.CreateInstance(p) as Profile);

            service.AddScoped(ctx => new MapperConfiguration(cfg =>
            {
                foreach (var profile in autoMapperProfiles)
                {
                    cfg.AddProfile(profile);
                }
            }));

            service.AddScoped(ctx => ctx.GetService<MapperConfiguration>().CreateMapper());
        }

        static IEnumerable<AssemblyName> EnumerateAllAssemblies()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            yield return executingAssembly.GetName();

            foreach (var assembly in executingAssembly.GetReferencedAssemblies())
            {
                yield return assembly;
            }
        }
    }
}