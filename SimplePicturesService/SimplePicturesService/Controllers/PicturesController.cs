using SimplePicturesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SimplePicturesService.Controllers
{
    public class PicturesController : ApiController
    {
        [ResponseType(typeof(IEnumerable<Picture>))]
        [Route("api/pictureAlbums/{pictureAlbumId}/pictures", Name="Pictures")]
        public IHttpActionResult GetPictures(int pictureAlbumId)
        {
            var pictures = DataStore.GetPictures(pictureAlbumId);
            if (pictures != null)
            {
                return Ok(pictures);
            }
            return NotFound();
        }

        [ResponseType(typeof(Picture))]
        [Route("api/pictureAlbums/{pictureAlbumId}/pictures/{pictureId}", Name = "Picture")]
        public IHttpActionResult GetPicture(int pictureAlbumId, int pictureId)
        {
            var picture = DataStore.GetPicture(pictureAlbumId, pictureId);
            if (picture != null)
            {
                return Ok(picture);
            }
            return NotFound();
        }

        [ResponseType(typeof(Picture))]
        [Route("api/pictureAlbums/{pictureAlbumId}/pictures/{pictureId}")]
        public IHttpActionResult PostPicture(int pictureAlbumId, Picture picture)
        {
            var createdPicture = DataStore.AddPicture(pictureAlbumId, picture);
            if (picture != null)
            {
                var location = Url.Route("Picture", new { pictureAlbumId = pictureAlbumId, pictureId = createdPicture.Id });
                return Created(location, createdPicture);
            }
            return NotFound();
        }

        [ResponseType(typeof(int))]
        [Route("api/pictureAlbums/{pictureAlbumId}/pictures/{pictureId}")]
        public IHttpActionResult UpdatePicture(Picture picture, int pictureAlbumId, int pictureId)
        {
            if (DataStore.UpdatePicture(picture, pictureAlbumId, pictureId) > 0)
            {
                return Ok(pictureId);
            }
            return NotFound();
        }

        [Route("api/pictureAlbums/{pictureAlbumId}/pictures/{pictureId}")]
        public void DeletePicture(int pictureAlbumId, int pictureId)
        {
            DataStore.DeletePicture(pictureAlbumId, pictureId);
        }
    }
}
