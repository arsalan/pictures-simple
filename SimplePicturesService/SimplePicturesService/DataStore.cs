using SimplePicturesService.Controllers;
using SimplePicturesService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplePicturesService
{
    public static class DataStore
    {
        private static IList<PictureAlbum> pictureAlbums;

        static DataStore()
        {
            pictureAlbums = new List<PictureAlbum>();
            for (var i = 1; i < 11; i++)
            {
                var newAlbum = new PictureAlbum { Id = i, Name = "Album " + i, Description = "Description " + i };
                var newPictures = new List<Picture>();

                for (var j = 1; j < 16; j++)
                {
                    newPictures.Add(new Picture { 
                        Id = i,
                        Name = "Picture #" + i,
                        Description = "Description for picture " + i,
                        Height = 200,
                        Width = 400,
                        //Url = "http://lorempixel.com/g/400/200",
                        Url = "http://placekitten.com/g/400/200",
                        Tags = new [] {"Picture", "Number" + i }
                    });
                }
                newAlbum.Pictures = newPictures;
                pictureAlbums.Add(newAlbum);
            }
        }

        public static IEnumerable<PictureAlbum> GetPictureAlbums()
        {
            return pictureAlbums;
        }

        public static PictureAlbum GetPictureAlbum(int id)
        {
            return pictureAlbums.FirstOrDefault(p => p.Id == id);
        }

        public static Picture GetPicture(int pictureAlbumId, int pictureId)
        {
            var album = pictureAlbums.FirstOrDefault(p => p.Id == pictureAlbumId);
            if (album != null)
            {
                return album.Pictures.FirstOrDefault(p => p.Id == pictureId);
            }

            return null;
        }

        public static IEnumerable<Picture> GetPictures(int pictureAlbumId)
        {
            var album = pictureAlbums.FirstOrDefault(p => p.Id == pictureAlbumId);
            if (album != null)
            {
                return album.Pictures;
            }

            return null;
        }

        public static PictureAlbum AddPictureAlbum(PictureAlbum album)
        {
            int id = pictureAlbums.Max(p => p.Id) + 1;
            album.Id = id;
            pictureAlbums.Add(album);
            return album;
        }

        public static Picture AddPicture(int pictureAlbumId, Picture picture)
        {
            var album = pictureAlbums.FirstOrDefault(p => p.Id == pictureAlbumId);
            if (album != null)
            {
                int id = album.Pictures.Max(p => p.Id) + 1;
                picture.Id = id;
                album.Pictures.Add(picture);
                return picture;
            }
            return null;
        }

        public static int UpdatePictureAlbum(PictureAlbum album, int id)
        {
            var albumToUpdate = pictureAlbums.FirstOrDefault(p => p.Id == id);
            if (albumToUpdate != null)
            {
                albumToUpdate.Name = album.Name;
                albumToUpdate.Description = album.Description;
                return id;
            }
            return -1;
        }

        public static int UpdatePicture(Picture picture, int pictureAlbumId, int pictureId)
        {
            var album = pictureAlbums.FirstOrDefault(p => p.Id == pictureAlbumId);
            if (album != null)
            {
                var pictureToUpdate = album.Pictures.FirstOrDefault(p => p.Id == pictureId);
                if (pictureToUpdate != null)
                {
                    pictureToUpdate.Name = picture.Name;
                    pictureToUpdate.Description = picture.Description;
                    pictureToUpdate.Height = picture.Height;
                    pictureToUpdate.Width = picture.Width;
                    pictureToUpdate.Tags = picture.Tags;
                    pictureToUpdate.Url = picture.Url;
                    return pictureId;
                }
            }
            return -1;
        }

        public static void DeletePictureAlbum(int id)
        {
            var albumToDelete = pictureAlbums.FirstOrDefault(p => p.Id == id);
            if (albumToDelete != null)
            {
                pictureAlbums.Remove(albumToDelete);
            }
        }

        public static void DeletePicture(int pictureAlbumId, int pictureId)
        {
            var album = pictureAlbums.FirstOrDefault(p => p.Id == pictureAlbumId);
            if (album != null)
            {
                var pictureToDelete = album.Pictures.FirstOrDefault(p => p.Id == pictureId);
                if (pictureToDelete != null)
                {
                    album.Pictures.Remove(pictureToDelete);
                }
            }
        }
    }
}