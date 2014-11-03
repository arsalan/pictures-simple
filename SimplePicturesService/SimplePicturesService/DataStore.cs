﻿using SimplePicturesService.Controllers;
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
                pictureAlbums.Add(new PictureAlbum { Id = i, Name = "Album " + i, Description = "Description " + i });
            }
        }

        public static IEnumerable<PictureAlbum> GetPictureAlbums()
        {
            return pictureAlbums;
        }

        public static PictureAlbum GetPictureAlbum(int id)
        {
            return pictureAlbums.Single(p => p.Id == id);
        }

        public static int AddPictureAlbum(PictureAlbum album)
        {
            int id = pictureAlbums.Max(p => p.Id) + 1;
            album.Id = id;
            pictureAlbums.Add(album);
            return id;
        }

        public static int UpdatePictureAlbum(PictureAlbum album, int id)
        {
            var albumToUpdate = pictureAlbums.Single(p => p.Id == id);
            albumToUpdate.Name = album.Name;
            albumToUpdate.Description = album.Description;
            albumToUpdate.PictureCount = album.PictureCount;
            return id;
        }
    }
}