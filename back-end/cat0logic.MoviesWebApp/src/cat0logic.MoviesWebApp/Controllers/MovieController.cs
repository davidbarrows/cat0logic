using System.Collections.Generic;
using System.Threading.Tasks;
using cat0logic.MoviesLibrary;
using Microsoft.AspNetCore.Mvc;

namespace cat0logic.MoviesWebApp.Controllers
{
    public class MovieController : Controller
    {
        private MovieService _movies;

        public MovieController(MovieService movies)
        {
            _movies = movies;
        }

        IActionResult Error(IEnumerable<string> errors)
        {
            foreach(var err in errors)
            {
                ModelState.AddModelError("", err);
            }
            return View("Error");
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var result = await _movies.GetAllAsync(page);
            if (result.IsAccessDenied)
            {
                return Forbid();
            }
            if (!result.Succeeded)
            {
                return Error(result.Errors);
            }

            return View(result.Value);
        }

        public async Task<IActionResult> Search(string searchTerm = null)
        {
            var result = await _movies.SearchAsync(searchTerm);
            if (result.IsAccessDenied)
            {
                return Forbid();
            }
            if (!result.Succeeded)
            {
                return Error(result.Errors);
            }

            return View(result.Value);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _movies.GetDetailsAsync(id);
            if (result.IsAccessDenied)
            {
                return Forbid();
            }
            if (!result.Succeeded)
            {
                return Error(result.Errors);
            }

            if (result.Value == null)
            {
                return RedirectToAction("Index");
            }

            return View(result.Value);
        }
    }
}
