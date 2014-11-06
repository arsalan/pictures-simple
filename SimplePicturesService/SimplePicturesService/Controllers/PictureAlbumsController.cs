using SimplePicturesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace SimplePicturesService.Controllers
{
    [EnableCors("*", "*", "*")]
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

        [Route("api/pictureAlbums/{id}", Name = "PictureAlbum")]
        [ResponseType(typeof(PictureAlbum))]
        public IHttpActionResult GetPictureAlbum(int id)
        {
            var foundAlbum = DataStore.GetPictureAlbum(id);
            if (foundAlbum != null)
            {
                return Ok(foundAlbum);
            }

            return NotFound();
        }

        [Route("api/pictureAlbums")]
        [ResponseType(typeof(PictureAlbum))]
        public IHttpActionResult PostPictureAlbum(PictureAlbum album)
        {
            var createdAlbum = DataStore.AddPictureAlbum(album);
            var location = Url.Route("PictureAlbum", new { id = createdAlbum.Id });
            return Created(location, createdAlbum);
        }

        [Route("api/pictureAlbums/{id}")]
        [ResponseType(typeof(int))]
        public IHttpActionResult PutPictureAlbum(PictureAlbum album, int id)
        {
            var updatedAlbum = DataStore.UpdatePictureAlbum(album, id);
            if (updatedAlbum != null)
            {
                return Ok(updatedAlbum);
            }
            return NotFound();
        }

        [Route("api/pictureAlbums/{id}")]
        public void DeletePictureAlbum(int id)
        {
            DataStore.DeletePictureAlbum(id);
        }
    }
}
