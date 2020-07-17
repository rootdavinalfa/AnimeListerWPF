// Copyright 2020 Davin Alfarizky Putra Basudewa
// WPF Implementation of AnimizeLister
// Based on Kotlin Version. Unfortunately Kotlin version not open sourced
// This Program just for testing only using WPF technology
using AnimeListerWPF.lib;
using AnimeListerWPF.model;
using AnimeListerWPF.ui;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimeListerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int currentPage = 1;
        private ViewModel vm;

        public MainWindow()
        {
            InitializeComponent();
            vm = new ViewModel();
            dgvAnimeList.ItemsSource = vm.AnimeLists;
        }


        private async void refreshData()
        {
            var page = currentPage.ToString();
            //Get object from RESTAPI connector with async to avoid UI Thread Blocking
            AnimeList anim = await Task.Run(() => RESTAPIConnector.GetAnimeList($"anim/list/package/page/{page}"));

            //Check if anim on AnimeList IList is 0, if 0 then reset counter to 1 otherwise iterate
            if (anim.anim.Count == 0 && anim.error == true)
            {
                //initDGV();
                currentPage = 1;
                refreshData();
                //allList.Clear();
            }
            else if (anim.anim.Count == 0 && anim.error == false)
            {
                //dgvAnimeList.ItemsSource = vm.AnimeLists;
                currentPage = 1;
            }
            else
            {
                foreach (Anime i in anim.anim)
                {
                    vm.Add(new Anime
                    {
                        package_anim = i.package_anim,
                        name_anim = i.name_anim,
                        rating = i.rating,
                        cover = i.cover
                    });
                }
                currentPage += 1;
                refreshData();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            refreshData();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            vm.Clear();
            currentPage = 1;
            refreshData();
        }

        private void dgvAnimeList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ItemsControl.ContainerFromElement((DataGrid)sender,
                                        e.OriginalSource as DependencyObject) as DataGridRow;

            if (row == null) return;
            Anime anim = (Anime)dgvAnimeList.CurrentItem;
            var detailWindow = new DetailWindow();
            detailWindow.pkgID = anim.package_anim;
            detailWindow.ShowDialog();
        }
    }
}
