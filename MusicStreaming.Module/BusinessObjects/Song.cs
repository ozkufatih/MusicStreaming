using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;

namespace MusicStreaming.Module.BusinessObjects
{
    [NavigationItem("Create")]
    public class Song : BaseObject
    {
        public virtual string Title { get; set; }

        public virtual double Duration { get; set; }

        public virtual Album? Album { get; set; }

        public virtual IList<Playlist> Playlists { get; set; } = new ObservableCollection<Playlist>();
    }
}
