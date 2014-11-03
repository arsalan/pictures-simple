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
        private static IList<PictureAlbum> pictureAlbums;

        public PictureAlbumsController()
        {
            pictureAlbums = new List<PictureAlbum>();
            for (var i = 1; i < 11; i++)
            {
                pictureAlbums.Add(new PictureAlbum { Id = i, Name = "Album " + i, Description = "Description " + i });
            }
        }

        [Route("api/pictureAlbums")]
        public IEnumerable<PictureAlbum> GetPictureAlbums()
        {
            return DataStore.GetPictureAlbums();
        }

        [Route("api/pictureAlbums/{id}")]
        public PictureAlbum GetPictureAlbum(int id)
        {
            return DataStore.GetPictureAlbum(id);
        }

        [Route("api/pictureAlbums")]
        public int Post(PictureAlbum album)
        {
            return DataStore.AddPictureAlbum(album);
        }

        [Route("api/pictureAlbums/{id}")]
        public int Put(PictureAlbum album, int id)
        {
            return DataStore.UpdatePictureAlbum(album, id);
        }
    }
}
