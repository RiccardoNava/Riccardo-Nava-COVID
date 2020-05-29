using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp35
{
    class Program
    {
        static async Task Main(string[] args)
        {
            HttpClient Client = new HttpClient();
            List<ProvinciaUltima> lista = new List<ProvinciaUltima>();
            string contenuto = await Client.GetStringAsync("https://raw.githubusercontent.com/pcm-dpc/COVID-19/master/dati-json/dpc-covid19-ita-province-latest.json"); //ultime dati delle province
            var provinceultimadeserializateall = JsonConvert.DeserializeObject<ProvinciaUltima[]>(contenuto);
            foreach (var item in provinceultimadeserializateall)
            {
                lista.Add(item);
            }


            StreamReader stream2 = new StreamReader(@"C:\Users\ricca\Downloads\provinceallegerito.txt");
            bool finito2 = false;
            List<Coordinate> listaprovince = new List<Coordinate>();
            while (!finito2)
            {
                
                string a = stream2.ReadLine();
                if (a == null) finito2 = true;
                else
                {
                    List<double[]> lista2 = new List<Double[]>();
                    Coordinate coordinate = new Coordinate() { };
                    string nome2 = stream2.ReadLine();
                    coordinate.nome = nome2;
                    int b = int.Parse(a);
                    for (int i = 0; i < b - 1; i++)
                    {
                        double lat = double.Parse(stream2.ReadLine());
                        double lon = double.Parse(stream2.ReadLine());
                        Double[] position = new double[] { lat, lon };
                        lista2.Add(position);
                    }
                    coordinate.posizioni = lista2;
                    listaprovince.Add(coordinate);
                }
            }
                foreach (var item in listaprovince)
                {
                string b = "";
                    var aa = from s in lista where s.denominazione_provincia.Equals(item.nome) select s;
                //try
                //{
                //    b = aa.FirstOrDefault().denominazione_provincia;
                //}
                //catch (System.NullReferenceException e)
                //{
                //    Console.WriteLine(item.nome);
                //}
                if (aa.Count() == 0)
                {
                    Console.WriteLine(item.nome);
                }


            }


            

        }
    }
}
