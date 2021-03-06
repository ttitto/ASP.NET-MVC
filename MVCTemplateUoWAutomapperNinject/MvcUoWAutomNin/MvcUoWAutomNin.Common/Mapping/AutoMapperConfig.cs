﻿namespace MvcUoWAutomNin.Common.Mapping
{
    using AutoMapper;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class AutoMapperConfig
    {
        public static void Execute()
        {
            var callingAssemblyTypes = Assembly.GetCallingAssembly().GetExportedTypes();
            var executingAssemblyTypes = Assembly.GetExecutingAssembly().GetExportedTypes();
            var types = callingAssemblyTypes.Union(executingAssemblyTypes);

            LoadStandardMappings(types);

            LoadCustomMappings(types);
        }

        private static void LoadStandardMappings(IEnumerable<Type> types)
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

            foreach (var map in maps)
            {
                Mapper.CreateMap(map.Source, map.Destination);
            }
        }

        private static void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                              !t.IsAbstract &&
                              !t.IsInterface
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

            foreach (var map in maps)
            {
                map.CreateMappings(Mapper.Configuration);
            }
        }
    }
}