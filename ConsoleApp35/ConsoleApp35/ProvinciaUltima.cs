using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp35
{
    public class ProvinciaUltima
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
}
