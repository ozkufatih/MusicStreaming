using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStreaming.Module.BusinessObjects
{
    [NavigationItem("People")]
    public class User : BaseObject
    {
        public virtual string UserName { get; set; }

        [FieldSize(255)]
        public virtual string Email { get; set; }

        public virtual DateTime? BirthDate { get; set; }

        [InverseProperty("CreatedBy")]
        public virtual IList<Playlist> CreatedPlaylists { get; set; } = new ObservableCollection<Playlist>();

        [InverseProperty("Followers")]
        public virtual IList<Playlist> FollowedPlaylists { get; set; } = new ObservableCollection<Playlist>();
    }
}
