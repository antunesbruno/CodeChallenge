﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMovies.Arc.Models.Interfaces
{
    public interface IGenres : IModel
    {
        int Id { get; set; }
        string Name { get; set; }
    }
}
