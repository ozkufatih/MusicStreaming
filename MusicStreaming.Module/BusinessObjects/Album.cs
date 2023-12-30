using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;
using System.Collections.ObjectModel;

namespace MusicStreaming.Module.BusinessObjects
{
    [NavigationItem("Create")]
    public class Album : BaseObject
    {
        public virtual string Title { get; set; }

        public virtual string Year { get; set; }

        public virtual DateTime? ReleaseDate { get; set; } = DateTime.Now;

        public virtual Artist? Artist { get; set; }

        public virtual IList<Song> Songs { get; set; } = new ObservableCollection<Song>();
    }
}
