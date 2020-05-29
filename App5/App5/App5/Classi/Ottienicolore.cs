using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    class Ottienicolore
    {
        static List<int> valoriRegioni { get; set; }
        static List<int> valoriProvince { get; set; }
        static bool calcolato { get; set; }



        public static async Task<double> getvalorenormalizatoreg(string nomeregione)
        {
            if (calcolato == false)
            {
                await calcolaregioni();
                await calcolaprovince();
                calcolato = true;
            }
            var a = valoriRegioni.ToArray();

            if (nomeregione != "Trentino-Alto Adige")
            {
                var regione = await App.Database.GetRegioniUltimaspecificheAsync(nomeregione);
                return (regione.totale_casi - a.Average()) / (a.Max() - a.Min());
            }
            else
            {
                var bolzano = await App.Database.GetRegioniUltimaspecificheAsync("P.A. Bolzano");
                var trentino = await App.Database.GetRegioniUltimaspecificheAsync("P.A. Trento");
                var somma = bolzano.totale_casi + trentino.totale_casi;
                return (somma -a.Average()) / (a.Max() - a.Min());
            }
        }
        public static async Task<double> getvalorenormalizatopro(string nomeregione)
        {
            if (calcolato == false)
            {
                await calcolaregioni();
                await calcolaprovince();
                calcolato = true;
            }
            var a = valoriProvince.ToArray();
            var pro = await App.Database.GetProvinceUltimaspecificheAsync(nomeregione);
            return (pro.totale_casi - a.Average()) / (a.Max() - a.Min());
        }
        public static async Task calcolaregioni()
        {
            int sommabalzanotrento = 0;
            var regioni = await App.Database.GetRegioneUltimaAsync();
            List<int> lista = new List<int>();
            foreach (var item in regioni)
            {
                if (item.denominazione_regione == "P.A. Bolzano" || item.denominazione_regione == "P.A. Trento")
                {
                    sommabalzanotrento += item.totale_casi;
                }
                else lista.Add(item.totale_casi);
            }
            
            lista.Add(sommabalzanotrento);
            valoriRegioni = lista;
        }

        public static async Task<string> getcodicecolereg(string nome)
        {
            var valorenormalizato = await getvalorenormalizatoreg(nome);
            if (valorenormalizato >= -1 && valorenormalizato < 0)
            {
                return "#fef0d9";
            }
            else if (valorenormalizato >= 0 && valorenormalizato < 0.25)
            {
                return "#fdcc8a";
            }
            else if (valorenormalizato >= -0.25 && valorenormalizato < 0.5)
            {
                return "#fc8d59";
            }
            else if (valorenormalizato >= 0.5 && valorenormalizato < 0.75)
            {
                return "#e34a33";
            }
            else if (valorenormalizato >= 0.75)
            {
                return "#b30000";
            }
            else return "#000000";
        }
        public static async Task<string> getcodicecolepro(string nome)
        {
            var valorenormalizato = await getvalorenormalizatopro(nome);
            if (valorenormalizato >= -1 && valorenormalizato < 0)
            {
                return "#fef0d9";
            }
            else if (valorenormalizato >= 0 && valorenormalizato < 0.25)
            {
                return "#fdcc8a";
            }
            else if (valorenormalizato >= -0.25 && valorenormalizato < 0.5)
            {
                return "#fc8d59";
            }
            else if (valorenormalizato >= 0.5 && valorenormalizato < 0.75)
            {
                return "#e34a33";
            }
            else if (valorenormalizato >= 0.75)
            {
                return "#b30000";
            }
            else return "#000000";
        }
        public static async Task calcolaprovince()
        {
            var provincie = await App.Database.GetProvinciaUltimaAsync();
            List<int> lista = new List<int>();
            foreach (var item in provincie)
            {
                lista.Add(item.totale_casi);
            };
            valoriProvince = lista;
        }


    }
    class Ottienicoloredata
    {
        static List<int> valoriRegioni { get; set; }
        static List<int> valoriProvince { get; set; }
        public static bool calcolato { get; set; }



        public static async Task<double> getvalorenormalizatotimereg(string nomeregione, DateTime Time)
        {
            if (calcolato == false)
            {
                await calcolaregionitime(Time);
                await calcolaprovincetime(Time);
                calcolato = true;
            }
            var a = valoriRegioni.ToArray();
            if (nomeregione != "Trentino-Alto Adige")
            {
                var regione = await App.Database.GetRegionispecifichetimeAsync(nomeregione, Time);
                return (regione.First().totale_casi - a.Average()) / (a.Max() - a.Min());
            }
            else
            {
                var bolzano = await App.Database.GetRegionispecifichetimeAsync("P.A. Bolzano", Time);
                var trentino = await App.Database.GetRegionispecifichetimeAsync("P.A. Trento", Time);
                var somma = bolzano.First().totale_casi + trentino.First().totale_casi;
                return (somma - a.Average()) / (a.Max() - a.Min());
            }
        }
        public static async Task<double> getvalorenormalizatotimepro(string nomeregione, DateTime time)
        {
                if (calcolato == false)
            {
                await calcolaregionitime(time);
                await calcolaprovincetime(time);
                calcolato = true;
            }
            var a = valoriProvince.ToArray();

            var pro = await App.Database.GetProvincespecifichetimeAsync(nomeregione, time);
            return (pro.First().totale_casi - a.Average()) / (a.Max() - a.Min());

        }
        public static async Task calcolaregionitime(DateTime time)
        {
            int sommabalzanotrento = 0;
            var regioni = await App.Database.GetRegionitimeAsync(time);
            List<int> lista = new List<int>();
            foreach (var item in regioni)
            {
                if (item.denominazione_regione == "P.A. Bolzano" || item.denominazione_regione == "P.A. Trento")
                {
                    sommabalzanotrento += item.totale_casi;
                }
                else lista.Add(item.totale_casi);
            }
            lista.Add(sommabalzanotrento);
            var a = lista.ToArray();
            Array.Sort(a);
            valoriRegioni = a.ToList();
        }

        public static async Task<string> getcodicecoleregtime(string nome, DateTime time)
        {
            var valorenormalizato = await getvalorenormalizatotimereg(nome, time);
            if (valorenormalizato >= -1 && valorenormalizato < 0)
            {
                return "#fef0d9";
            }
            else if (valorenormalizato >= 0 && valorenormalizato < 0.25)
            {
                return "#fdcc8a";
            }
            else if (valorenormalizato >= -0.25 && valorenormalizato < 0.5)
            {
                return "#fc8d59";
            }
            else if (valorenormalizato >= 0.5 && valorenormalizato < 0.75)
            {
                return "#e34a33";
            }
            else if (valorenormalizato >= 0.75)
            {
                return "#b30000";
            }
            else return "#000000";
        }
        public static async Task<string> getcodicecoleprotime(string nome, DateTime time)
        {
            var valorenormalizato = await getvalorenormalizatotimepro(nome, time);
            if (valorenormalizato >= -1 && valorenormalizato < 0)
            {
                return "#fef0d9";
            }
            else if (valorenormalizato >= 0 && valorenormalizato < 0.25)
            {
                return "#fdcc8a";
            }
            else if (valorenormalizato >= -0.25 && valorenormalizato < 0.5)
            {
                return "#fc8d59";
            }
            else if (valorenormalizato >= 0.5 && valorenormalizato < 0.75)
            {
                return "#e34a33";
            }
            else if (valorenormalizato >= 0.75)
            {
                return "#b30000";
            }
            else return "#000000";
        }
        public static async Task calcolaprovincetime(DateTime time)
        {
            var provincie = await App.Database.GetProvincetimeAsync(time);
            List<int> lista = new List<int>();
            foreach (var item in provincie)
            {
                lista.Add(item.totale_casi);
            }
            var a = lista.ToArray();
            Array.Sort(a);
            valoriProvince = a.ToList();
        }


    }
}
