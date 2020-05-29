using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NazioneResoconto : ContentPage
    {
        public NazioneResoconto()
        {
            InitializeComponent();
            
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var nazione = await App.Database.GetNazioneUltimaAsync();
            Ricoverati_con_sintomi.Text = nazione.First().ricoverati_con_sintomi.ToString();
            Terapia_intensiva.Text = nazione.First().terapia_intensiva.ToString();
            Totale_ospedalizati.Text = nazione.First().totale_ospedalizzati.ToString();
            Isolamento_domiciliare.Text = nazione.First().isolamento_domiciliale.ToString();
            Totale_positivi.Text = nazione.First().totale_positivi.ToString();
            Variazione_totale_positivi.Text = nazione.First().variazione_totale_positivi.ToString();
            Nuovi_positivi.Text = nazione.First().nuovi_positivi.ToString();
            Dimessi_guariti.Text = nazione.First().dimessi_guariti.ToString();
            Deceduti.Text = nazione.First().deceduti.ToString();
            Totale_casi.Text = nazione.First().totale_casi.ToString();
            Tamponi.Text = nazione.First().tamponi.ToString();
            Casi_testati.Text = nazione.First().casi_testati.ToString();
            var chart = new LineChart() { Entries = await Getentries.GetentrieNaz() };
            chartView.Chart = chart;
        }

    }
}