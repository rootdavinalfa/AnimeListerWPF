using AnimeListerWPF.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeListerWPF.lib
{
    public class ViewModel
    {
        public ObservableCollection<Anime> AnimeLists { get; set; } = new ObservableCollection<Anime>();

        public void Add(Anime item)
        {
            AnimeLists.Add(item);
        }
        
        public void Clear()
        {
            AnimeLists.Clear();
        }

        public int Count()
        {
            return AnimeLists.Count;
        }
    }
}
