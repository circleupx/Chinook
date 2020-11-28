﻿using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class AlbumRoutes
    {
        public const string AlbumResourceCollection = AlbumResourceKeyWords.Self;
        public const string AlbumResource = AlbumResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}