using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyApplication.Models;
using VidlyApplication.Dtos;
using System.Data.Entity;
using AutoMapper;

namespace VidlyApplication.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _contex;

        public MoviesController()
        {
            _contex = new ApplicationDbContext();
        }

        //GET api/movies

        public IHttpActionResult GetMovies (string query=null)
        {
            var moviesQuery = _contex.Movies
                .Include(c => c.Genre)
                .Where(c=>c.NumberAvailable>0);

            if (!String.IsNullOrWhiteSpace(query))
            {
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));
            }

            var moviesDtos=moviesQuery
                .ToList().
                Select(Mapper.Map<Movie, MovieDto>);
            return Ok(moviesDtos);
        }

        //GET api/movies/1

        public IHttpActionResult GetMovie(int Id)
        {
            var movie = _contex.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST api/movies/
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _contex.Movies.Add(movie);
            _contex.SaveChanges();
            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);

        }

        //PUT /api/movies/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(MovieDto movieDto, int Id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var movieInDb = _contex.Movies.Single(m => m.Id == Id);
            if (movieInDb==null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            _contex.SaveChanges();
            return Ok();

        }

        //DELETE api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _contex.Movies.SingleOrDefault(m => m.Id == Id);
            if (movie==null)
            {
                return NotFound();
            }
            _contex.Movies.Remove(movie);
            _contex.SaveChanges();
            return Ok();
        }


    }
}
