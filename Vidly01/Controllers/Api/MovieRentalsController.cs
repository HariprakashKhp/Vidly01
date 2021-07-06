using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly01.Dtos;
using Vidly01.Models;

namespace Vidly01.Controllers.Api
{
    public class MovieRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public MovieRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRental(RentalDto RentalDto)
        {
            
            var customer = _context.Customers.Single(c => c.Id == RentalDto.CustomerId);
            

            var movies = _context.Movies.Where(m => RentalDto.MovieIds.Contains(m.Id)).ToList();
            

            foreach(var movie in movies)
            {
                if(movie.NumberAvailable == 0)
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

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
