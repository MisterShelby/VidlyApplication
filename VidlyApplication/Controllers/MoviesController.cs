using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyApplication.Models;
using VidlyApplication.ViewModels;
using System.Data.Entity;   

namespace VidlyApplication.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private ApplicationDbContext _contex;

        public MoviesController()
        {
            _contex = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _contex.Dispose();
        }

        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var movie = _contex.Movies.Include(m=>m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie==null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = _contex.Genres.ToList()
            };
            return View("MovieForm",viewModel);
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
                    
                    Genres = _contex.Genres.ToList()
                };
                return View("MovieForm", viewModel);

            }
            if (movie.Id==0)
            {
                movie.DateAdded = DateTime.Now;
                _contex.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _contex.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = DateTime.Now;
            }
            _contex.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit (int id)
        {
            var movie = _contex.Movies.Single(m => m.Id == id);
            if (movie==null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _contex.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }

        
    }
}