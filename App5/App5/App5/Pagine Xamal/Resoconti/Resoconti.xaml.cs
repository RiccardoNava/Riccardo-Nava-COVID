using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Resoconti : ContentPage
    { 
    List<string> nazioneeregioni = new List<string>() {
         "abruzzo", "basilicata", "calabria", "campania", "emilia-romagna", "friuli-venezia giulia", "lazio", "liguria", "lombardia", "marche",
         "molise", "piemonte", "puglia", "sardegna", "sicilia", "toscana", "trentino-alto adige", "umbria", "valle d'aosta", "veneto", "italia"
        };
        public static string provinciaselezionata;
        public static string regioneselezionata;
        public Resoconti()
        {
            InitializeComponent();
            searchResults.ItemsSource = DataService.listaregpronaz;
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
                searchResults.ItemsSource = DataService.GetSearchResults(e.NewTextValue);
        }

        private async void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            var sel = e.Item.ToString().ToLower();
            if (nazioneeregioni.Contains(sel))
            {
                if (sel == "italia")
                {
                    await Navigation.PushAsync(new NazioneResoconto());
                }
                else
                {
                    regioneselezionata = sel;
                    await Navigation.PushAsync(new RegioneResoconto());
                }
            }
            else
            {
                provinciaselezionata = sel;
                await Navigation.PushAsync(new ProvinciaResonto());
            }
        }
    }
}