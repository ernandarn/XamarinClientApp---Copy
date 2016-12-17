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
    public partial class EditJenisMotor : ContentPage
    {
        public EditJenisMotor()
        {
            InitializeComponent();
            btnEditJenisMotor.Clicked += BtnEditJenisMotor_Clicked;
            btnDeleteJenisMotor.Clicked += BtnDeleteJenisMotor_Clicked;
        }

        private async void BtnDeleteJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor/{id}", Method.DELETE);

            _request.AddParameter("id", txtIdJenisMotor.Text);
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

        private async void BtnEditJenisMotor_Clicked(object sender, EventArgs e)
        {
            var _request = new RestRequest("api/JenisMotor", Method.PUT);
            var newJenisMotor = new JenisMotor
            {
                IdJenisMotor = Convert.ToInt32(txtIdJenisMotor.Text),
                NamaMerk = txtNamaMerk.Text,
                NamaJenisMotor = txtNamaJenisMotor.Text
            };

            _request.AddBody(newJenisMotor);
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
