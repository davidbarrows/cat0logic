using System.Threading.Tasks;
using cat0logic.MoviesLibrary;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace cat0logic.MoviesWebApp
{
    public class AccessTokenAccessor : IAccessTokenAccessor
    {
        private readonly IHttpContextAccessor _context;

        public AccessTokenAccessor(IHttpContextAccessor context)
        {
            _context = context;
        }

        public Task<string> GetAccessTokenAsync()
        {
            return _context.HttpContext.GetTokenAsync("access_token");
        }
    }
}
