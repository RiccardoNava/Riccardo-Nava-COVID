using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Nazione>().Wait();
            _database.CreateTableAsync<Province>().Wait();
            _database.CreateTableAsync<Regioni>().Wait();
            _database.CreateTableAsync<RegioneUltima>().Wait();
            _database.CreateTableAsync<ProvinciaUltima>().Wait();
            _database.CreateTableAsync<NazioneUltima>().Wait();
        }
        //comandi nazioni
        public Task<List<Nazione>> GetNazioneAsync()
        {
            return _database.Table<Nazione>().ToListAsync();
        }
        public Task<int> SaveNazioneAsync(Nazione item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateNazioneAsync(Nazione item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteNazioneAsync(Nazione item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllNazioneAsync()
        {
            return _database.DeleteAllAsync<Nazione>();
        }

        //comandi province
        public Task<List<Province>> GetProvinceAsync()
        {
            return _database.Table<Province>().ToListAsync();
        }
        public Task<int> SaveProvinceAsync(Province item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateProvinceAsync(Province item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteProvinceAsync(Province item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllProvinceAsync()
        {
            return _database.DeleteAllAsync<Province>();
        }
        public async Task<List<Province>> GetProvincespecificheAsync(string nome)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var provi = await GetProvinceAsync();
            var prov = new List<Province>();
            provi.ForEach(r =>
            {
                if (r.denominazione_provincia.ToLower() == nome.ToLower()) prov.Add(r);
            });
            return prov;
        }
        public async Task<List<Province>> GetProvincetimeAsync(DateTime time)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var provi = await GetProvinceAsync();
            var prov = new List<Province>();
            provi.ForEach(r =>
            {
                if (r.data.DayOfYear == time.DayOfYear) prov.Add(r);
            });
            return prov;
        }
        public async Task<List<Province>> GetProvincespecifichetimeAsync(string nome, DateTime time)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var provi = await GetProvinceAsync();
            var prov = new List<Province>();
            provi.ForEach(r =>
            {
                if (r.denominazione_provincia.ToLower() == nome.ToLower()) prov.Add(r);
            });
            var pro = new List<Province>();
            prov.ForEach(r =>
            {
                if (r.data.DayOfYear == time.DayOfYear) pro.Add(r);
            });
            return pro;
        }


        //comandi Regioni
        public Task<List<Regioni>> GetRegioniAsync()
        {
            return _database.Table<Regioni>().ToListAsync();
        }
        public Task<int> SaveRegioniAsync(Regioni item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateRegioniAsync(Regioni item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteRegioniAsync(Regioni item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllRegioniAsync()
        {
            return _database.DeleteAllAsync<Regioni>();
        }
        public async Task<List<Regioni>> GetRegionispecificheAsync(string nome)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var regs = await GetRegioniAsync();
            var ris = new List<Regioni>();
            regs.ForEach(r =>
            {
                if (r.denominazione_regione.ToLower() == nome.ToLower()) ris.Add(r);
            });
            return ris;
        }
        public async Task<List<Regioni>> GetRegionitimeAsync(DateTime time)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var regs = await GetRegioniAsync();
            var ris = new List<Regioni>();
            regs.ForEach(r =>
            {
                if (r.data.DayOfYear == time.DayOfYear) ris.Add(r);
            });
            return ris;
        }
        public async Task<List<Regioni>> GetRegionispecifichetimeAsync(string nome, DateTime time)
        {
            //anche se rallenta un sacco la popolazione della mappa, il foreach è l'unico modo per compilare la mappa visto che non funziona nessun tipo di query con la table provina e regioni, non ho capito il motivo però
            var regs = await GetRegioniAsync();
            var ris = new List<Regioni>();
            regs.ForEach(r =>
            {
                if (r.denominazione_regione.ToLower() == nome.ToLower()) ris.Add(r);
            });
            var ros = new List<Regioni>();
            ris.ForEach(r =>
            {
                if (r.data.DayOfYear == time.DayOfYear) ros.Add(r);
            });
            return ros;

        }
        //Nazioneultima
        public Task<List<NazioneUltima>> GetNazioneUltimaAsync()
        {
            return _database.Table<NazioneUltima>().ToListAsync();
        }
        public Task<int> SaveNazioneUltimaAsync(NazioneUltima item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateNazioneUltimaAsync(NazioneUltima item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteNazioneUltimaAsync(NazioneUltima item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllNazioneUltimaAsync()
        {
            return _database.DeleteAllAsync<NazioneUltima>();
        }
        //RegioneUltima
        public Task<List<RegioneUltima>> GetRegioneUltimaAsync()
        {
            return _database.Table<RegioneUltima>().ToListAsync();
        }
        public Task<int> SaveRegioneUltimaAsync(RegioneUltima item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateRegioneUltimaAsync(RegioneUltima item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteRegioneUltimaAsync(RegioneUltima item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllRegioneUltimaAsync()
        {
            return _database.DeleteAllAsync<RegioneUltima>();
        }
        public async Task<RegioneUltima> GetRegioniUltimaspecificheAsync(string nome)
        {
            var reg = from s in _database.Table<RegioneUltima>() where s.denominazione_regione.ToLower().Equals(nome.ToLower()) select s;
            return await reg.FirstOrDefaultAsync();
        }
        //provinceUltima
        public Task<List<ProvinciaUltima>> GetProvinciaUltimaAsync()
        {
            return _database.Table<ProvinciaUltima>().ToListAsync();
        }
        public Task<int> SaveProvinciaUltimaAsync(ProvinciaUltima item)
        {
            return _database.InsertAsync(item);
        }
        public Task<int> UpdateProvinciaUltimaAsync(ProvinciaUltima item)
        {
            return _database.UpdateAsync(item);
        }
        public Task<int> DeleteProvinciaUltimaAsync(ProvinciaUltima item)
        {
            return _database.DeleteAsync(item);
        }
        public Task<int> DeleteAllProvinciaUltimaAsync()
        {
            return _database.DeleteAllAsync<ProvinciaUltima>();
        }
        public async Task<ProvinciaUltima> GetProvinceUltimaspecificheAsync(string nome)
        {
            var pro = from s in _database.Table<ProvinciaUltima>() where s.denominazione_provincia.ToLower().Equals(nome.ToLower()) select s;
            return await pro.FirstOrDefaultAsync();
        }
    }
}
