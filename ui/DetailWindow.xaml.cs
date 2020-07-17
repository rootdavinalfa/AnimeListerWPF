// Copyright 2020 Davin Alfarizky Putra Basudewa
// WPF Implementation of AnimizeLister
// Based on Kotlin Version. Unfortunately Kotlin version not open sourced
// This Program just for testing only using WPF technology
using AnimeListerWPF.lib;
using AnimeListerWPF.model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnimeListerWPF.ui
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private Details anim;
        public string pkgID;
        public DetailWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (pkgID != null)
            {
                getInfo();
            }
        }
        private async void getInfo()
        {
            anim = await Task.Run(() => RESTAPIConnector.GetInfo(String.Format("package/info/{0}", pkgID)));
            if (anim != null)
            {
                var detail = anim.anim[0];
                detailTitle.Text = detail.name_catalogue;
                this.Title = detail.name_catalogue;
                detailRating.Content = String.Format("Rating: {0}", detail.rating);
                detailPackage.Content = detail.package_anim;
                detailSynopsis.Text = detail.synopsis;
                StringBuilder sb = new StringBuilder();
                var index = 0;
                var count = detail.genre.Count;
                foreach (string i in detail.genre)
                {
                    if (index < count - 1)
                    {
                        sb.Append(String.Format("{0}, ", i));
                    }
                    else if (index == count - 1)
                    {
                        sb.Append(i);
                    }
                    index += 1;
                }
                detailGenre.Text = sb.ToString();
                attachImage(detail.cover);
            }
        }
        private void attachImage(string cover)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(cover, UriKind.Absolute);
            bitmap.EndInit();

            detailImage.Source = bitmap;
            detailBG.Source = detailImage.Source.Clone();
        }

        private void btnAnimize_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(String.Format("https://animize.dvnlabs.xyz/anim/package/{0}", pkgID));
        }

        private void btnMAL_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(String.Format("https://myanimelist.net/anime/{0}", anim.anim[0].mal_id));
        }
    }
}
