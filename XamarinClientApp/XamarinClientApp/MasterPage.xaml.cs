using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XamarinClientApp.Models;

namespace XamarinClientApp
{
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView2; } }
        public MasterPage()
        {
            InitializeComponent();

            var masterPage = new List<MasterPageItems>();
            masterPage.Add(new MasterPageItems
            {
                Title = "Barang",
                IconSource = "icon.png",
                TargetType = typeof(BarangPage)
            });
            masterPage.Add(new MasterPageItems
            {
                Title = "Jenis Motor",
                IconSource = "icon.png",
                TargetType = typeof(JenisMotorPage)
            });
            masterPage.Add(new MasterPageItems
            {
                Title = "Kategori",
                IconSource = "icon.png",
                TargetType = typeof(KategoriPage)
            });
            listView2.ItemsSource = masterPage;

        }
    }
}
