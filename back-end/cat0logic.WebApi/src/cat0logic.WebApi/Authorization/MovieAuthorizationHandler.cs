using System.Linq;
using System.Threading.Tasks;
using cat0logic.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace cat0logic.WebApi.Authorization
{
    public class MovieOperations
    {
        public static readonly OperationAuthorizationRequirement Review =
            new OperationAuthorizationRequirement { Name = "Review" };
    }

    public class MovieAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, MovieDetails>
    {
        private readonly ReviewPermissionService _reviewPermissions;

        public MovieAuthorizationHandler(ReviewPermissionService reviewPermissions)
        {
            _reviewPermissions = reviewPermissions;
        }

        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            MovieDetails movie)
        {
            if (requirement == MovieOperations.Review)
            {
                if (context.User.HasClaim("role", "Reviewer"))
                {
                    var allowed = _reviewPermissions.GetAllowedCountries(context.User);
                    if (allowed.Contains(movie.CountryName))
                    {
                        context.Succeed(requirement);
                    }
                }
            }

            return Task.FromResult(0);
        }
    }
}
