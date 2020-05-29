using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace App5
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {



        public MainPage()
        {

            InitializeComponent();
            MasterPage.listView.ItemSelected += OnItemSelected;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (!Page1.controllofatto) await Navigation.PushModalAsync(new Page1());





        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                MasterPage.listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
