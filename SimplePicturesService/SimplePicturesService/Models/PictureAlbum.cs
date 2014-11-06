using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplePicturesService.Models
{
    public class PictureAlbum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PictureCount
        {
            get
            {
                return this.Pictures != null ? this.Pictures.Count : 0;
            }
        }
        public ICollection<Picture> Pictures { get; set; }
    }
}
