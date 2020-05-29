using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public static bool controllofatto = false;
        private string myStringProperty;
        public string MyStringProperty
        {
            get { return myStringProperty; }
            set
            {
                myStringProperty = value;
                OnPropertyChanged(nameof(MyStringProperty));
            }
        }
        public async Task controllosepassatempo()
        {
            var nazione = await App.Database.GetNazioneUltimaAsync();
            if (nazione.Count() != 0)
            {
                var a = DateTime.Now.Subtract(nazione.ToArray()[0].data);
                if (a.TotalHours >= 36)
                {
                    try
                    {
                        await App.Database.DeleteAllNazioneAsync();
                        await App.Database.DeleteAllProvinceAsync();
                        await App.Database.DeleteAllRegioniAsync();
                        await App.Database.DeleteAllNazioneUltimaAsync();
                        await App.Database.DeleteAllProvinciaUltimaAsync();
                        await App.Database.DeleteAllRegioneUltimaAsync();
                        await alldownload.recuperainformazioniall();
                    }
                    catch
                    {
                        BindingContext = this;

                        MyStringProperty = "c'è stato un errore, rinstallare l'app perfavore";
                    }
                }
            }
            else await alldownload.recuperainformazioniall();
        }
        public Page1()
        {
            InitializeComponent();
            BindingContext = this;
            MyStringProperty = "Sto aggiornando il Database, attendere qualche minuto e non spegnere lo schermo";

        }
        protected override async void OnAppearing()
        {
            var firstLaunch = VersionTracking.IsFirstLaunchEver;

            if (firstLaunch)
            {
                await alldownload.recuperainformazioniall();

            }
            else await controllosepassatempo();
            controllofatto = true;
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}