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
    public partial class RegioneResoconto : ContentPage
    {
        public RegioneResoconto()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (Resoconti.regioneselezionata == "trentino-alto adige")
            {
                var regione1 = await App.Database.GetRegioniUltimaspecificheAsync("P.A.Trento");
                var regione2 = await App.Database.GetRegioniUltimaspecificheAsync("P.A. Bolzano");
                denominazione_regione.Text = "Trentino-Alto Adige";
                Ricoverati_con_sintomi.Text = (regione1.ricoverati_con_sintomi + regione2.ricoverati_con_sintomi).ToString();
                Terapia_intensiva.Text = (regione1.terapia_intensiva + regione2.terapia_intensiva).ToString();
                Totale_ospedalizati.Text = (regione1.totale_ospedalizzati + regione2.totale_ospedalizzati).ToString();
                Isolamento_domiciliare.Text = (regione1.isolamento_domiciliale + regione2.isolamento_domiciliale).ToString();
                Totale_positivi.Text = (regione1.totale_positivi+ regione2.totale_positivi).ToString();
                Variazione_totale_positivi.Text = (regione1.variazione_totale_positivi+ regione2.variazione_totale_positivi).ToString();
                Nuovi_positivi.Text = (regione1.nuovi_positivi+ regione2.nuovi_positivi).ToString();
                Dimessi_guariti.Text = (regione1.dimessi_guariti + regione2.dimessi_guariti).ToString();
                Deceduti.Text = (regione1.deceduti + regione2.deceduti).ToString();
                total_cas.Text = (regione1.totale_casi+ regione2.totale_casi).ToString();
                Tampon.Text = (regione1.tamponi + regione2.tamponi).ToString();
                Casi_test.Text = (regione1.casi_testati+ regione2.casi_testati).ToString(); 

            }
            else
            {
                var regione = await App.Database.GetRegioniUltimaspecificheAsync(Resoconti.regioneselezionata);
                denominazione_regione.Text = regione.denominazione_regione;
                Ricoverati_con_sintomi.Text = regione.ricoverati_con_sintomi.ToString();
                Terapia_intensiva.Text = regione.terapia_intensiva.ToString();
                Totale_ospedalizati.Text = regione.totale_ospedalizzati.ToString();
                Isolamento_domiciliare.Text = regione.isolamento_domiciliale.ToString();
                Totale_positivi.Text = regione.totale_positivi.ToString();
                Variazione_totale_positivi.Text = regione.variazione_totale_positivi.ToString();
                Nuovi_positivi.Text = regione.nuovi_positivi.ToString();
                Dimessi_guariti.Text = regione.dimessi_guariti.ToString();
                Deceduti.Text = regione.deceduti.ToString();
                total_cas.Text = regione.totale_casi.ToString();
                Tampon.Text = regione.tamponi.ToString();
                Casi_test.Text = regione.casi_testati.ToString();
            }
            var chart = new LineChart() { Entries = await Getentries.GetentriesReg(Resoconti.regioneselezionata) };
            chartView.Chart = chart;
        }
    }
}