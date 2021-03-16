using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {


        private static List<Models.Movie> movies = new List<Models.Movie>()
        {
           new Models.Movie() { ID = Guid.NewGuid(), MoveiL = 140, MovieName= "Thor" },
           new Models.Movie() { ID = Guid.NewGuid(), MoveiL = 120, MovieName= "Captin America" },
           new Models.Movie() { ID = Guid.NewGuid(), MoveiL = 200, MovieName= "Star Wars" }
        };

        [HttpGet]
        public Models.Movie[] Get()
        {
            return movies.ToArray();
        }


        [HttpPost]
        public void Post([FromBody] Models.Movie movie)
        {
            if (movie.ID == Guid.Empty)
                movie.ID = Guid.NewGuid();

            movies.Add(movie);
        }

        [HttpPut]
        public void Put([FromBody] Models.Movie movie)
        {
            Models.Movie currnetMovie = movies.FirstOrDefault(x => x.ID == movie.ID);
            currnetMovie.MovieName = currnetMovie.MovieName;
            currnetMovie.MoveiL = currnetMovie.MoveiL;
        }

        [HttpDelete]
        public void Remove(Guid id)
        {
            movies.RemoveAll(movie => movie.ID == id);
        }


    }
}
