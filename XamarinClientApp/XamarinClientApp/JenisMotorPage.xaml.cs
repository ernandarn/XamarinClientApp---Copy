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
    public partial class JenisMotorPage : ContentPage
    {
        public JenisMotorPage()
        {
            InitializeComponent();
            listJenisMotor.ItemTapped += ListJenisMotor_ItemTapped;
            btnTambahJenisMotor.Clicked += BtnTambahJenisMotor_Clicked;
        }

        private void BtnTambahJenisMotor_Clicked(object sender, EventArgs e)
        {
            TambahJenisMotor tambah = new TambahJenisMotor();
            Navigation.PushAsync(tambah);
        }

        protected override void OnAppearing()
        {
            this.BindingContext = new JenisMotorViewModels();
        }

        private void ListJenisMotor_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            JenisMotor item = (JenisMotor)e.Item;
            EditJenisMotor editJM = new EditJenisMotor();
            editJM.BindingContext = item;
            Navigation.PushAsync(editJM);
        }
    }
}
