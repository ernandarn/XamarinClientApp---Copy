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
    public partial class EditBarang : ContentPage
    {
        public EditBarang()
        {
            InitializeComponent();
            btnEditBarang.Clicked += BtnEditBarang_Clicked;
            btnDeleteBarang.Clicked += BtnDeleteBarang_Clicked;
        }

        private async void BtnDeleteBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang/{id}", Method.DELETE);

            _request.AddParameter("id", txtKodeBarang.Text);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }

        private RestClient _client =
         new RestClient("http://contohinventory.azurewebsites.net");

        private async void BtnEditBarang_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/Barang", Method.PUT);
            var newBarang = new Barang
            {
                KodeBarang = txtKodeBarang.Text,
                IdKategori = Convert.ToInt16(txtIdKategori.Text),
                IdJenisMotor = Convert.ToInt16(txtIdJenisMotor.Text),
                Nama = txtNama.Text,
                Stok = Convert.ToInt16(txtStok.Text),
                HargaBeli = Convert.ToInt16(txtHargaBeli.Text),
                HargaJual = Convert.ToInt16(txtHargaJual.Text),
                TanggalBeli = Convert.ToDateTime(txtTanggalBeli.Text)
            };

            _request.AddBody(newBarang);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
