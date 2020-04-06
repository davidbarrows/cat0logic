using System.Threading.Tasks;

namespace cat0logic.MoviesLibrary
{
    public interface IAccessTokenAccessor
    {
        Task<string> GetAccessTokenAsync();
    }
}
