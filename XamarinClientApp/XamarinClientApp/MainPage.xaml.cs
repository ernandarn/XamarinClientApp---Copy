using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinClientApp.Models;

namespace XamarinClientApp
{
    public partial class MainPage : MasterDetailPage
    {
        public List<MasterPageItems> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent();
            //masterPage.ListView.ItemSelected += ListView_ItemSelected;
            menuList = new List<MasterPageItems>();

            var page1 = new MasterPageItems() { Title = "Barang", IconSource = "itemIcon1.png", TargetType = typeof(BarangPage) };
            var page2 = new MasterPageItems() { Title = "Jenis Motor", IconSource = "itemIcon2.png", TargetType = typeof(JenisMotorPage) };
            var page3 = new MasterPageItems() { Title = "Kategori", IconSource = "itemIcon3.png", TargetType = typeof(KategoriPage) };

            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);

            navigationDrawerList.ItemsSource = menuList;

            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(BarangPage)));
        }

        //private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MasterPageItems;
        //    if (item != null)
        //    {
        //        Detail =
        //             new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        //        masterPage.ListView.SelectedItem = null;
        //        IsPresented = false;
        //    }
        //}

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItems)e.SelectedItem;
            Type page = item.TargetType;

            Detail = new NavigationPage((Page)Activator.CreateInstance(page));
            IsPresented = false;
        }
    }
}
