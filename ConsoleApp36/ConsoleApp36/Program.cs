using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<string> varia = new List<string>();
            HttpClient Client = new HttpClient();
            varia.Add("Italia");
            var contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-province-latest.json"); //ultime dati delle province
            var provinceultimadeserializateall = JsonConvert.DeserializeObject<Province[]>(contenuto);
            foreach (var item in provinceultimadeserializateall)
            {
                varia.Add(item.denominazione_provincia);
            }
            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni-latest.json"); //ultime dati delle regioni
            var regioniultimideserializateall = JsonConvert.DeserializeObject<Regioni[]>(contenuto);
            foreach (var item in regioniultimideserializateall)
            {
                varia.Add(item.denominazione_regione);
            }

            foreach (var item in varia)
            {
                if (item == "In fase di definizione/aggiornamento")
                {

                }
                else if (item == "P.A. Trento") { }
                else if (item == "P.A. Bolzano") Console.Write("\"" + "Trentino Alto-Adige" + "\"" + ", ");
                else Console.Write("\""+item+"\"" + ", ");
            }
        }
    }
}
