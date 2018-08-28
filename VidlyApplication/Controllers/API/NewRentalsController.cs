using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyApplication.Dtos;
using VidlyApplication.Models;

namespace VidlyApplication.Controllers.API
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _contex;

        public NewRentalsController()
        {
            _contex = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals ( NewRentalDto newRental)
        {
            var customer = _contex.Customers.Single(c => c.Id == newRental.CustomerId);
            var movies = _contex.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable==0)
                {
                    return BadRequest("Movie is not available");
                }
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _contex.Rentals.Add(rental);
            }
            _contex.SaveChanges();
            return Ok();
        }
    }
}
