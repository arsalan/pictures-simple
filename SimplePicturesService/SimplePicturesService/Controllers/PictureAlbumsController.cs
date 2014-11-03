using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimplePicturesService.Controllers
{
    public class PictureAlbumsController : ApiController
    {
        private IList<PictureAlbum> pictureAlbums;

        public PictureAlbumsController()
        {
            this.pictureAlbums = new List<PictureAlbum>();
            for (var i = 1; i < 11; i++)
            {
                pictureAlbums.Add(new PictureAlbum { Id = i, Name = "Album " + i, Description = "Description " + i });
            }
        }

        [Route("api/pictureAlbums")]
        public IEnumerable<PictureAlbum> Get()
        {
            return this.pictureAlbums;
        }
    }
}
