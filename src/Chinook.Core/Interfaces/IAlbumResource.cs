﻿using JsonApiFramework.JsonApi;
using System.Threading.Tasks;

namespace Chinook.Core.Interfaces
{
    public interface IAlbumResource
    {
        Task<Document> GetAlbumResource(int resourceId);
        Task<Document> GetAlbumResourceCollection();
        Task<Document> GetAlbumResourceToArtistResource(int resourceId);
        Task<Document> GetAlbumResourceToTrackResourceCollection(int resourceId);
    }
}