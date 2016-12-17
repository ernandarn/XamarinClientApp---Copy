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
    public partial class TambahKategoriPage : ContentPage
    {
        //private ObservableCollection<Kategori> myList;
        public TambahKategoriPage()
        {
            InitializeComponent();
            //this.myList = myList;
            //this.BindingContext = new KategoriViewModel();
            btnSimpanKategori.Clicked += BtnSimpanKategori_Clicked;
        }

        private RestClient _client =
         new RestClient("http://contohinventory.azurewebsites.net");

        private async void BtnSimpanKategori_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Kategori", Method.POST);
            var newKategori = new Kategori { NamaKategori = txtNamaKategori.Text };
            _request.AddBody(newKategori);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new KategoriPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
