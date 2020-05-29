using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Regionipagina : ContentPage
    {
        public Regionipagina()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            Position position = new Position(41.902782, 12.496366);
            MapSpan mapSpan = new MapSpan(position, 11, 13);
            Mappa.MoveToRegion(mapSpan);
            List<Coordinate> lista = Classe_supporto.listaposizioneregioni;
            foreach (var item in lista)
            {
                Polygon polygon = new Polygon
                {
                    StrokeWidth = 4,
                    StrokeColor = Color.FromHex("#424242"),
                    FillColor = Color.FromHex(await Ottienicolore.getcodicecolereg(item.nome))

                };
                foreach (var item2 in item.posizioni)
                {
                    polygon.Geopath.Add(new Position(item2.Latitude, item2.Longitude));
                }
                Mappa.MapElements.Add(polygon);

            }
        }
        private async void datepicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime time = e.NewDate;
            time = time.AddHours(18);
            Mappa.MapElements.Clear();
            if (time.DayOfYear != DateTime.Now.DayOfYear)
            {
                List<Coordinate> lista = Classe_supporto.listaposizioneregioni;

                foreach (var item in lista)
                {
                    Polygon polygon = new Polygon
                    {
                        StrokeWidth = 4,
                        StrokeColor = Color.FromHex("#424242"),
                        FillColor = Color.FromHex(await Ottienicoloredata.getcodicecoleregtime(item.nome, time)),

                    };
                    foreach (var item2 in item.posizioni)
                    {
                        polygon.Geopath.Add(new Position(item2.Latitude, item2.Longitude));
                    }
                    Mappa.MapElements.Add(polygon);

                }
                Ottienicoloredata.calcolato = false;
            }
            else OnAppearing();
        }
    }
}