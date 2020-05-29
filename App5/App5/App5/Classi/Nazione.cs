using System;
using System.Collections.Generic;
using System.Text;

namespace App5
{
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
