using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MusicStreaming.Module.BusinessObjects
{
    [NavigationItem("People")]
    public class Artist : BaseObject
    {
        public virtual string Name { get; set; }

        public virtual string Genre { get; set; }

        [StringLength(4096)]
        public virtual string Biography { get; set; }

        public virtual IList<Album> Albums { get; set; } = new ObservableCollection<Album>();

    }
}
