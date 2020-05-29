using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace App5.Droid
{
    [Activity(Label = "App5", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] LocationPermissions =
        {
            Manifest.Permission.AccessCoarseLocation,
            Manifest.Permission.AccessFineLocation
        };
        protected override void OnStart()
        {
            base.OnStart();
            if ((int)Build.VERSION.SdkInt >= 23)
            {
                if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
                {
                    RequestPermissions(LocationPermissions, RequestLocationId);
                }
                else
                {
                    // Permissions already granted - display a message.
                }
            }
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            StreamReader stream = new StreamReader(Assets.Open("regioniallegerito.txt"));
            bool finito = false;
            List<Coordinate> listaregioni = new List<Coordinate>();
            while (!finito)
            {
                string a = stream.ReadLine();
                if (a == null) finito = true;
                else
                {
                    List<Position> lista = new List<Position>();
                    Coordinate coordinate = new Coordinate();
                    string nome = stream.ReadLine();
                    coordinate.nome = nome;
                    int b = int.Parse(a);
                    for (int i = 0; i < b - 1; i++)
                    {
                        double lat = double.Parse(stream.ReadLine());
                        double lon = double.Parse(stream.ReadLine());
                        Position position = new Position(lat, lon);
                        lista.Add(position);
                    }
                    coordinate.posizioni = lista;
                    listaregioni.Add(coordinate);
                }



            }
            Classe_supporto.listaposizioneregioni = listaregioni;
            StreamReader stream2 = new StreamReader(Assets.Open("provinceallegerito.txt"));
            bool finito2 = false;
            List<Coordinate> listaprovince = new List<Coordinate>();
            while (!finito2)
            {
                string a = stream2.ReadLine();
                if (a == null) finito2 = true;
                else
                {
                    List<Position> lista = new List<Position>();
                    Coordinate coordinate = new Coordinate() { };
                    string nome2 = stream2.ReadLine();
                    coordinate.nome = nome2;
                    int b = int.Parse(a);
                    for (int i = 0; i < b - 1; i++)
                    {
                        double lat = double.Parse(stream2.ReadLine());
                        double lon = double.Parse(stream2.ReadLine());
                        Position position = new Position(lat, lon);
                        lista.Add(position);
                    }
                    coordinate.posizioni = lista;
                    listaprovince.Add(coordinate);
                }
                Classe_supporto.listaposizioniProvince = listaprovince;


            }
            LoadApplication(new App());

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            if (requestCode == RequestLocationId)
            {
                if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
                { }
                else
                { }
            }
            else
            {
                base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            }
        }
    }
}