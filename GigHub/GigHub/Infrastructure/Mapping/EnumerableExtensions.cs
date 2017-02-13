namespace GigHub.Mapping
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web.Mvc;

    public static class EnumerableExtensions
    {
        public static IEnumerable<TDestination> To<TDestination>(this IEnumerable<object> source, params Expression<Func<TDestination, object>>[] membersToExpand)
        {

            return source.Select(x => AutoMapperConfig.Configuration.CreateMapper().Map<TDestination>(x)).ToList();

            //return source.AsQueryable().
            //    ProjectTo(AutoMapperConfig.Configuration, membersToExpand);
        }

        public static TDestination To<TDestination, TSource>(this object source, params Expression<Func<TDestination, object>>[] membersToExpand) where TSource : class where TDestination : class
        {
            //var result = new[] { source }.AsQueryable().ProjectTo(AutoMapperConfig.Configuration, membersToExpand).FirstOrDefault();
            var result = AutoMapperConfig.Configuration.CreateMapper().Map<TSource, TDestination>(source as TSource);
            return result;
        }

        public static SelectList ToSelectList(this IEnumerable<SelectListItem> items)
        {
            var selectList = new SelectList(items);
            return selectList;
        }
    }
}
