using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp34
{
    class Program
    {
        static void Main(string[] args)
        {
            //    StreamReader reader = new StreamReader(@"C:\Users\ricca\Downloads\regioni.txt");
            //    string testoregioni = reader.ReadToEnd();
            //    StreamWriter writer = new StreamWriter(@"C:\Users\ricca\Downloads\regioniallegerito.txt");
            //    var json = JsonConvert.DeserializeObject<Regioneeprovincie[]>(testoregioni);
            //    foreach (var item in json)
            //    {
            //        writer.WriteLine(item.geometry.coordinates[0].GetLength(0)+1);
            //        writer.WriteLine(item.DEN_PROV);
            //        for (int i = 0; i < item.geometry.coordinates[0].GetLength(0); i++)
            //        {
            //            writer.WriteLine(item.geometry.coordinates[0][i][1]);
            //            writer.WriteLine(item.geometry.coordinates[0][i][0]);
            //        }
            //    }
            //    reader.Close();
            //    writer.Close();

            StreamReader reader2 = new StreamReader(@"C:\Users\ricca\Downloads\aa.txt");
            string testoprovince = reader2.ReadToEnd();
            StreamWriter writer2 = new StreamWriter(@"C:\Users\ricca\Downloads\provinceallegerito2.txt");
            var json2 = JsonConvert.DeserializeObject<Regioneeprovincie[]>(testoprovince);
            foreach (var item in json2)
            {
                writer2.WriteLine(item.geometry.coordinates[0].GetLength(0) + 1);
                if (item.properties.DEN_PROV == "-")
                {
                    writer2.WriteLine(item.properties.DEN_CM);
                }
                else writer2.WriteLine(item.properties.DEN_PROV);
                for (int i = 0; i < item.geometry.coordinates[0].GetLength(0); i++)
                {
                    writer2.WriteLine(item.geometry.coordinates[0][i][1]);
                    writer2.WriteLine(item.geometry.coordinates[0][i][0]);
                }
            }
            reader2.Close();
            writer2.Close();


        }
    }
}
