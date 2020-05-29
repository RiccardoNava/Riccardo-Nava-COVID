using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entry = Microcharts.Entry;
using System.Threading.Tasks;
using SkiaSharp;

namespace App5
{
    public static class Getentries
    {
        public static int vecchitotali { get; set; }
        public static async Task<Entry[]> GetentriesReg(string nome)
        {
            if (nome != "trentino-alto adige")
            {
                var lista = await App.Database.GetRegionispecificheAsync(nome);
                var entrys = new List<Entry>();
                foreach (var item in lista)
                {
                    var ent = new Entry(item.nuovi_positivi);
                    //ent.Label = item.data.ToString();
                    //ent.ValueLabel = item.totale_casi.ToString();
                    ent.Color = SKColor.Parse("#bb161d");
                    entrys.Add(ent);
                }
                return entrys.ToArray();
            }
            else
            {
                var lista1 = await App.Database.GetRegionispecificheAsync("P.A.Trento");
                var lista2 = await App.Database.GetRegionispecificheAsync("P.A. Bolzano");
                var entrys = new List<Entry>();
                var ar1 = lista1.ToArray();
                var ar2 = lista2.ToArray();
                for (int i = 0; i < ar1.Length; i++)
                {

                    var ent = new Entry(ar1[i].nuovi_positivi+ar2[i].nuovi_positivi);
                    //ent.Label = ar1[i].data.ToString();
                    //ent.ValueLabel = (ar1[i].totale_casi+ar2[i].totale_casi).ToString();
                    ent.Color = SKColor.Parse("#bb161d"); 
                    entrys.Add(ent);


                }
                return entrys.ToArray();
            }


        }
        public static async Task<Entry[]> GetentrieNaz()
        {
            var lista = await App.Database.GetNazioneAsync();
            var entrys = new List<Entry>();
            foreach (var item in lista)
            {
                var ent = new Entry(item.nuovi_positivi);
                //ent.Label = item.data.ToString();
                //ent.ValueLabel = item.totale_casi.ToString();
                ent.Color = SKColor.Parse("#bb161d");
                entrys.Add(ent);
            }
            return entrys.ToArray();
        }
        public static async Task<Entry[]> GetentriesPro(string nome)
        {
            var lista = await App.Database.GetProvincespecificheAsync(nome);
            var entrys = new List<Entry>();
            vecchitotali = 0;
            foreach (var item in lista)
            {
                int nuovipos = item.totale_casi - vecchitotali;
                vecchitotali = item.totale_casi;
                var ent = new Entry(nuovipos);
                //ent.Label = item.data.ToString();
                //ent.ValueLabel = item.totale_casi.ToString();
                ent.Color = SKColor.Parse("#bb161d");
                entrys.Add(ent);
            }
            return entrys.ToArray();
        }



    }
}
