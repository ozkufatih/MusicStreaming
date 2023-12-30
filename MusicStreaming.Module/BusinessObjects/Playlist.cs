using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStreaming.Module.BusinessObjects
{
    [NavigationItem("Create")]
    public class Playlist : BaseObject
    {
        public virtual string Title { get; set; }

        [StringLength(4096)]
        public virtual string Description { get; set; }

        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User? CreatedBy { get; set; }

        [InverseProperty("FollowedPlaylists")]
        public virtual IList<User> Followers { get; set; } = new ObservableCollection<User>();

        public virtual IList<Song> Songs { get; set; } = new ObservableCollection<Song>();
    }

}
