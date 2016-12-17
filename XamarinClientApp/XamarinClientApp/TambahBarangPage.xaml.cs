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
    public partial class TambahBarangPage : ContentPage
    {
        public TambahBarangPage()
        {
            InitializeComponent();
            btnSimpanBarang.Clicked += BtnSimpanBarang_Clicked;
        }

        private RestClient _client =
      new RestClient("http://contohinventory.azurewebsites.net");

        private async void BtnSimpanBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.POST);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                IdKategori = Convert.ToInt16(txtIdKategori.Text),
                IdJenisMotor = Convert.ToInt16(txtIdJenisMotor.Text),
                Nama = txtNama.Text,
                Stok = Convert.ToInt32(txtStok.Text),
                HargaBeli = Convert.ToInt32(txtHargaBeli.Text),
                HargaJual = Convert.ToInt32(txtHargaJual.Text),
                TanggalBeli = Convert.ToDateTime(txtTanggalBeli.Text)
            };
            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new BarangPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
