using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ark.Library.Backend.API.Entities.Base;

namespace Ark.Library.Backend.API.Entities
{
    public class Book : Things
    {
        public string? Title { get; set; }
        public string? Writer { get; set; }
        public double Price { get; set; }
    }
}