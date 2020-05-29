using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Microcharts;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProvinciaResonto : ContentPage
    {
        public ProvinciaResonto()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var provincia = await App.Database.GetProvinceUltimaspecificheAsync(Resoconti.provinciaselezionata);
            denominazione_provincia.Text = provincia.denominazione_provincia;
            Nome_Regione.Text = provincia.denominazione_regione;
            Sigla_Provincia.Text = provincia.sigla_provincia;
            Totale_casi.Text = provincia.totale_casi.ToString();
            var chart = new LineChart() { Entries = await Getentries.GetentriesPro(Resoconti.provinciaselezionata) };
            chartView.Chart = chart;
        }
    }
}