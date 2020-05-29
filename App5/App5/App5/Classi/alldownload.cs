using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class alldownload
    {
        public static async Task recuperainformazioniall()
        {
            HttpClient Client = new HttpClient();
            string contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni.json"); //tutte i dati delle regioni
            var regionideserializateall = JsonConvert.DeserializeObject<Regioni[]>(contenuto);
            foreach (var item in regionideserializateall)
            {
                await App.Database.SaveRegioniAsync(item);
            }
            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-province.json"); //tutte le province
            var provincedeserializateall = JsonConvert.DeserializeObject<Province[]>(contenuto);
            foreach (var item in provincedeserializateall)
            {
                await App.Database.SaveProvinceAsync(item);
            }
            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-andamento-nazionale.json"); //tutte le nazioni
            var nazioneserializateall = JsonConvert.DeserializeObject<Nazione[]>(contenuto);
            foreach (var item in nazioneserializateall)
            {
                await App.Database.SaveNazioneAsync(item);
            }
            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-regioni-latest.json"); //ultime dati delle regioni
            var regioniultimideserializateall = JsonConvert.DeserializeObject<RegioneUltima[]>(contenuto);
            foreach (var item in regioniultimideserializateall)
            {
                await App.Database.SaveRegioneUltimaAsync(item);
            }
            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-province-latest.json"); //ultime dati delle province
            var provinceultimadeserializateall = JsonConvert.DeserializeObject<ProvinciaUltima[]>(contenuto);
            foreach (var item in provinceultimadeserializateall)
            {
                await App.Database.SaveProvinciaUltimaAsync(item);
            }

            contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-andamento-nazionale-latest.json"); //ultimi dati della nazione
            var nazioneultimadeserializateall = JsonConvert.DeserializeObject<NazioneUltima[]>(contenuto);
            foreach (var item in nazioneultimadeserializateall)
            {
                await App.Database.SaveNazioneUltimaAsync(item);
            }



        }
    }
}
