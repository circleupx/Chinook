namespace Chinook.Core.ServiceModels
{
    public partial class PlaylistTrackServiceModel
    {
        public long PlaylistId { get; set; }
        public long TrackId { get; set; }

        public virtual PlaylistServiceModel Playlist { get; set; }
        public virtual TrackServiceModel Track { get; set; }
    }
}
