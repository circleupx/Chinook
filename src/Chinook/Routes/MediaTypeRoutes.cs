﻿using Chinook.Core.Constants;

namespace Chinook.Web.Routes
{
    public static class MediaTypeRoutes
    {
        public const string MediaTypeResourceCollection =  MediaTypeResourceKeyWords.Self;
        public const string MediaTypeResource = MediaTypeResourceKeyWords.Self + StandardRouteValues.ForwardSlash + StandardRouteValues.IdUriTemplate;
    }
}