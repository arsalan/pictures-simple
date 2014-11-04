using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePicturesService
{
    public class PictureAlbum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PictureCount { get; set; }
        public ICollection<Picture> Pictures { get; set; }
    }
}
