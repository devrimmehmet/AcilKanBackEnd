﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcilKan.Domain.Entities
{
    public class Mission // About sayfasındaki misyonumuz alanı
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; }
    }
}
