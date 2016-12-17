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

namespace XamarinClientApp.ViewModels
{
    public class SearchBarang : BindableObject
    {
        private RestClient _client =
           new RestClient("http://contohinventory.azurewebsites.net");

        private ObservableCollection<Barang> listBarang;
        public ObservableCollection<Barang> ListBarang
        {
            get { return listBarang; }
            set { listBarang = value; OnPropertyChanged("ListBarang"); }
        }

        private async void RefreshDataAsync(string nama)
        {
            RestRequest _request = new RestRequest("api/Barang/?Nama=" + nama, Method.GET);
            var _response = await _client.Execute<List<Barang>>(_request);
            ListBarang = new ObservableCollection<Barang>(_response.Data);
        }

        public SearchBarang(string nama)
        {
            RefreshDataAsync(nama);
        }
    }
    
}
