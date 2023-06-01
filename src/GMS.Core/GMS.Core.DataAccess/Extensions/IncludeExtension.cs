using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GMS.Core.DataAccess.Extensions
{
    public static class IncludeExtension
    {
        public static IQueryable<T> IncludeEx<T>(this IQueryable<T> query, 
            params Expression<Func<T, object>>[] includes)
            where T : class
        {
           if (includes != null)
                return includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;
        }
    }
}
