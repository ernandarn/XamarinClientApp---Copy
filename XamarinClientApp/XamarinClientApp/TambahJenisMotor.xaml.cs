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
    public partial class TambahJenisMotor : ContentPage
    {
        public TambahJenisMotor()
        {
            InitializeComponent();
            btnSimpanJenisMotor.Clicked += BtnSimpanJenisMotor_Clicked;
        }

        private RestClient _client =
        new RestClient("http://contohinventory.azurewebsites.net");

        private async void BtnSimpanJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.POST);
            var newJenisMotor = new JenisMotor { NamaMerk = txtNamaMerk.Text, NamaJenisMotor = txtNamaJenisMotor.Text };
            _request.AddBody(newJenisMotor);
            try
            {
                var _response = await _client.Execute(_request);
                if (_response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    await Navigation.PushAsync(new JenisMotorPage());
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "Error : " + ex.Message, "OK");
            }
        }
    }
}
