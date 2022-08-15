using famagustaHospital.Entities.Models;
using famagustaHospital.Repository.Extensions.Utility;
using System.Linq.Dynamic.Core;

namespace famagustaHospital.Repository.Extensions
{
    public static class UserRepositoryExtension
    {
        public static IQueryable<SystemUser> FilterUsers(this IQueryable<SystemUser> users)
        {
            return users;
        }
        public static IQueryable<SystemUser> SearchUsers(this IQueryable<SystemUser> users, string? searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return users;
            var lowerCaseTerm = searchTerm.Trim().ToLower();

            return users.Where(e => (e.Name != null && e.Name.ToLower().Contains(lowerCaseTerm))
            || (e.UserName != null && e.UserName.ToLower().Contains(lowerCaseTerm))
            || (e.Email != null && e.Email.ToLower().Contains(lowerCaseTerm))
            );
        }
        public static IQueryable<SystemUser> SortUsers(this IQueryable<SystemUser> users, string? orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return users.OrderBy(e => e.Name);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<SystemUser>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return users.OrderBy(e => e.Name);

            return users.OrderBy(orderQuery);
        }

    }

}
