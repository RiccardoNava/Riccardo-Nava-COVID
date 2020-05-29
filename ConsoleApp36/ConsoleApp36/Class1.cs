using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp36
{
    public class Regioni
    {
        public DateTime data { get; set; }
        public string stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public int ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliale { get; set; }
        public int totale_positivi { get; set; }
        public int intvariazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public int? casi_testati { get; set; }
        public string note_it { get; set; }
        public string note_en { get; set; }
    }
    public class Province
    {
        public DateTime data { get; set; }
        public string Stato { get; set; }
        public int codice_regione { get; set; }
        public string denominazione_regione { get; set; }
        public int codice_provincia { get; set; }
        public string denominazione_provincia { get; set; }
        public string sigla_provincia { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public int totale_casi { get; set; }
        public string note_it { get; set; }
        public string note_en { get; set; }
    }
    public class Nazione
    {
        public DateTime data { get; set; }
        public string stato { get; set; }
        public int ricoverati_con_sintomi { get; set; }
        public int terapia_intensiva { get; set; }
        public int totale_ospedalizzati { get; set; }
        public int isolamento_domiciliale { get; set; }
        public int totale_positivi { get; set; }
        public int variazione_totale_positivi { get; set; }
        public int nuovi_positivi { get; set; }
        public int dimessi_guariti { get; set; }
        public int deceduti { get; set; }
        public int totale_casi { get; set; }
        public int tamponi { get; set; }
        public int? casi_testati { get; set; }
        public string note_it { get; set; }
        public string note_en { get; set; }


    }
}
