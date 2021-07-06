using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly01.Models;
using Vidly01.ViewModels;
using System.Data.Entity;

namespace Vidly01.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "shreak!" };
            var customers = new List<Customer>
            {
                new Customer {Name = "customer1"},
                new Customer {Name = "customer2"},
            };

            var viewModel = new RandomMoveViewModel()
            {
                movie = movie,
                customers = customers
            };
            return View(viewModel);
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genre = _context.Genre.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genre = genre
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genre.ToList(),
                };
                return View("MovieForm", viewModel);
            }

            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }else
            {
                var dbMovie = _context.Movies.Single(m => m.Id == movie.Id);
                dbMovie.Name = movie.Name;
                dbMovie.NumberInStock = movie.NumberInStock;
                dbMovie.ReleaseDate = Convert.ToDateTime(movie.ReleaseDate);
                dbMovie.genreId = movie.genreId;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);
            if(movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genre.ToList(),
            };

            return View("MovieForm", viewModel);
        }
    }
}