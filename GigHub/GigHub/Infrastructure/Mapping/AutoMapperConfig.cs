namespace GigHub.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoMapper;

    public class AutoMapperConfig
    {
        public static MapperConfiguration Configuration { get; private set; }

        public void Execute(params Assembly[] assemblies)
        {
            Configuration = new MapperConfiguration(
                cfg =>
                {
                    List<Type> types = new List<Type>();
                    for (int i = 0; i < assemblies.Length; i++)
                    {
                        types.AddRange(assemblies[i].GetExportedTypes());
                    }
                    LoadStandardMappings(types, cfg);
                    LoadReverseMappings(types, cfg);
                    LoadCustomMappings(types, cfg);
                });
        }

        private static void LoadStandardMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Source = i.GetGenericArguments()[0],
                            Destination = t
                        }).ToArray();
            for (int i = 0; i < maps.Count(); i++)
            {
                mapperConfiguration.CreateMap(maps[i].Source, maps[i].Destination);
            }
        }

        private static void LoadReverseMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select new
                        {
                            Destination = i.GetGenericArguments()[0],
                            Source = t
                        }).ToArray();

            for (int i = 0; i < maps.Count(); i++)
            {
                mapperConfiguration.CreateMap(maps[i].Source, maps[i].Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types, IMapperConfigurationExpression mapperConfiguration)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();
            for (int i = 0; i < maps.Count(); i++)
            {
                maps[i].CreateMappings(mapperConfiguration);
            }
        }
    }
}
