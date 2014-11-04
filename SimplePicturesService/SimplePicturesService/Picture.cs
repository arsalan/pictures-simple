using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePicturesService
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}