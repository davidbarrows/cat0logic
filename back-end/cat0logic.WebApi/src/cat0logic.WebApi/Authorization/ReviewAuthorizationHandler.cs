using System.Threading.Tasks;
using cat0logic.Library;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace cat0logic.WebApi.Authorization
{
    public class ReviewOperations
    {
        public static readonly OperationAuthorizationRequirement Edit =
            new OperationAuthorizationRequirement() { Name = "Edit" };
    }

    public class ReviewAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, MovieReview>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            MovieReview review)
        {
            if (context.User.HasClaim("role", "Admin"))
            {
                context.Succeed(requirement);
            }

            if (requirement == ReviewOperations.Edit)
            {
                var sub = context.User.FindFirst("sub")?.Value;
                if (sub != null && review.UserId == sub)
                {
                    context.Succeed(requirement);
                }
            }

            return Task.FromResult(0);
        }
    }
}
