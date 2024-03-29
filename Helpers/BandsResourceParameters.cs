﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandAPI.Helpers
{
    public class BandsResourceParameters
    {
        public string  MainGenre { get; set; }
        public string SearchQuery { get; set; }


        const int maxPageSize = 13;               // Maximun number of records per page 
        public int PageNumber { get; set; } = 1;  // Actual page

        private int _pageSize = 13;               // Number of records per page 

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }

        public string OrderBy { get; set; } = "Name";
        public string Fields { get; set; }
    }
}
