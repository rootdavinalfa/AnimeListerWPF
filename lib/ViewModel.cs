// Copyright 2020 Davin Alfarizky Putra Basudewa
// WPF Implementation of AnimizeLister
// Based on Kotlin Version. Unfortunately Kotlin version not open sourced
// This Program just for testing only using WPF technology
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
