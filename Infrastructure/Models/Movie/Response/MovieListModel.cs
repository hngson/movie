using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Models
{
    public class MovieListModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Year { get; set; }
        public string Country { get; set; }
    }
}
