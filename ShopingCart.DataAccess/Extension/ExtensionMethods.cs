using ShopingCart.DataAccess.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopingCart.DataAccess.Extension
{
    public static class ExtensionMethods
    {
        public static IQueryable<T> Paginate<T, TSortKey>(this IQueryable<T> query, Func<T, TSortKey> sortBy , int page, int count)
        {
            return query.AsQueryable()
                .Skip(page * count).Take(count);
        }

        public static IQueryable<T> Search<T>(this IQueryable<T> query, string filters)
        {
            IEnumerable<SearchModel> filterResult = JsonSerializer.Deserialize<IEnumerable<SearchModel>>(filters);
            if(filterResult.Count() == 0)
            {
                return query;
            }
            Expression? body = null;
            var param = Expression.Parameter(typeof(T), "_");
            foreach (var item in filterResult)
            {
                var member = Expression.Property(param, item.Property.ToString());
                var propertyType = ((PropertyInfo)member.Member).PropertyType;
                var constant = Expression.Constant(item.Value);
                var expression = Expression.Call(
                    Expression.Call(member, typeof(object).GetMethod("ToString")), "Contains", Type.EmptyTypes, Expression.Call(constant, typeof(object).GetMethod("ToString")));
                body = body == null ? expression : Expression.AndAlso(body, expression);
            }

            var result = Expression.Lambda<Func<T, bool>>(body, param).Compile();
            return query.Where(result).AsQueryable();
        }
    }
}
