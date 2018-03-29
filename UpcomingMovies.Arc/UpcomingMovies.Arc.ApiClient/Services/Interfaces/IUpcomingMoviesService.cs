﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpcomingMovies.Arc.Models;

namespace UpcomingMovies.Arc.ApiClient.Services
{
    public interface IUpcomingMoviesService
    {
        Task<List<UpcomingMovie>> GetAllUpComingMovies();
        Task<List<UpcomingMovie>> GetPagedUpcomingWithGenre();
    }
}