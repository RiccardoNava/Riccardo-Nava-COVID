using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App5
{
    public class DataService
    {
        public static List<string> listaregpronaz { get; }  = new List<string>
        { "Italia", "Chieti", "L'Aquila", "Pescara", "Teramo", "Matera", "Potenza", "Bolzano", "Catanzaro", "Cosenza", "Crotone", 
          "Reggio di Calabria", "Vibo Valentia", "Avellino", "Benevento", "Caserta", "Napoli", "Salerno", "Bologna", "Ferrara", 
          "Forlì-Cesena", "Modena", "Parma", "Piacenza", "Ravenna", "Reggio nell'Emilia", "Rimini", "Gorizia", "Pordenone", 
          "Trieste", "Udine", "Frosinone", "Latina", "Rieti", "Roma", "Viterbo", "Genova", "Imperia", "La Spezia", "Savona", "Bergamo",
          "Brescia", "Como", "Cremona", "Lecco", "Lodi", "Mantova", "Milano", "Monza e della Brianza", "Pavia", "Sondrio", "Varese", "Ancona",
          "Ascoli Piceno", "Fermo", "Macerata", "Pesaro e Urbino", "Campobasso", "Isernia", "Alessandria", "Asti", "Biella", "Cuneo", "Novara", "Torino",
          "Verbano-Cusio-Ossola", "Vercelli", "Bari", "Barletta-Andria-Trani", "Brindisi", "Foggia", "Lecce", "Taranto", "Cagliari", "Nuoro", "Oristano", "Sassari", 
          "Sud Sardegna", "Agrigento", "Caltanissetta", "Catania", "Enna", "Messina", "Palermo", "Ragusa", "Siracusa", "Trapani", "Arezzo", "Firenze", "Grosseto",
          "Livorno", "Lucca", "Massa Carrara", "Pisa", "Pistoia", "Prato", "Siena", "Trento", "Perugia", "Terni", "Aosta", "Belluno", "Padova", "Rovigo", "Treviso",
          "Venezia", "Verona", "Vicenza", "Abruzzo", "Basilicata", "Trentino Alto-Adige", "Calabria", "Campania", "Emilia-Romagna", "Friuli-Venezia Giulia", "Lazio",
          "Liguria", "Lombardia", "Marche", "Molise", "Piemonte", "Puglia", "Sardegna", "Sicilia", "Toscana", "Umbria", "Valle d'Aosta", "Veneto" };

        public static List<string> GetSearchResults(string queryString)
        {
            var normalizedQuery = queryString?.ToLower() ?? "";
            return listaregpronaz.Where(f => f.ToLowerInvariant().Contains(normalizedQuery)).ToList();
        }
    }
}
