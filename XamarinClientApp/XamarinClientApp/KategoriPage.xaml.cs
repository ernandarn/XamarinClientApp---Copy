using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using XamarinClientApp.ViewModels;

namespace XamarinClientApp
{
    public partial class KategoriPage : ContentPage
    {
        public KategoriPage()
        {
            InitializeComponent();
            listKategori.ItemTapped += ListKategori_ItemTapped;
            btnTambahKategori.Clicked += BtnTambahKategori_Clicked;
        }

        private void BtnTambahKategori_Clicked(object sender, EventArgs e)
        {
            TambahKategoriPage tambah = new TambahKategoriPage();
            Navigation.PushAsync(tambah);

        }

        protected override void OnAppearing()
        {
            this.BindingContext = new KategoriViewModel();
        }

        private void ListKategori_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Kategori item = (Kategori)e.Item;
            EditKategoriPage editPage = new EditKategoriPage();
            editPage.BindingContext = item;
            Navigation.PushAsync(editPage);
        }


        
    }
}
