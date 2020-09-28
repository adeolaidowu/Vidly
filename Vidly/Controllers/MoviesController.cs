using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Wonderwoman" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Serena"},
                new Customer { Name = "Tarzan"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int movieId)
        {
            return Content($"Id = {movieId}");
        }

        public ActionResult Index(int pageIndex = 1, string sortBy = "Name")
        {
            /*if (!pageIndex.HasValue) pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy)) sortBy = "Name";*/
            return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        }
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content($"{year}/{month}");
        }
    }
}