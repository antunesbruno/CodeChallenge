﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.ApiClient
{
    public interface IApiResult<T> : IApiMinify
    {
        T results { get; set; }
        int page { get; set; }
        int total_results { get; set; }
        object dates { get; set; }
        int total_pages { get; set; }
        bool Success { get; set; }
        string Message { get; set; }
    }
}
