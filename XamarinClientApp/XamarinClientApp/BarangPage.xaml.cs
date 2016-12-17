using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;
using XamarinClientApp.ViewModels;

namespace XamarinClientApp
{
    public partial class BarangPage : ContentPage
    {
        //private ObservableCollection<Barang> myList;
        public BarangPage()
        {
            InitializeComponent();
            listBarang.ItemTapped += ListBarang_ItemTapped;
            btnTambahBarang.Clicked += BtnTambahBarang_Clicked;
            btnSearchBarang.Clicked += BtnSearchBarang_Clicked;
            btnSearchKat.Clicked += BtnSearchKat_Clicked;
        }

        private void BtnSearchKat_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchKategori(txtSearchKat.Text);
        }

        private void BtnSearchBarang_Clicked(object sender, EventArgs e)
        {
            this.BindingContext = new SearchBarang(txtSearchBarang.Text);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new BarangViewModels();
        }

        private async void BtnTambahBarang_Clicked(object sender, EventArgs e)
        {
            //TambahBarang tambah = new TambahBarang();
            //Navigation.PushAsync(tambah);
            //await Navigation.PushAsync(new TambahBarang());
            await Navigation.PushAsync(new TambahBarangPage());
        }

        private void ListBarang_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Barang item = (Barang)e.Item;
            //EditBarang editBrg = new EditBarang();
            EditBarangPage editBrg = new EditBarangPage();
            editBrg.BindingContext = item;
            Navigation.PushAsync(editBrg);
        }
    }
}
