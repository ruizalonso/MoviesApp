using MoviesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Services
{
    public interface IAPIService
    {
        Task<List<Movie>> GetMovieByName(string name);

        Task<Movie> GetMovieById(string id);
    }
}
