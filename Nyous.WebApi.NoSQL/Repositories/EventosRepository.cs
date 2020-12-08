using MongoDB.Driver;
using Nyous.WebApi.NoSQL.Contexts;
using Nyous.WebApi.NoSQL.Domains;
using Nyous.WebApi.NoSQL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.WebApi.NoSQL.Repositories
{
    public class EventosRepository : IEventosRepository
    {
        private readonly IMongoCollection<EventoDomain> _eventos;

        public EventosRepository(INyousDatabaseSettings settings)
        {
            // Configurando connection string
            var client = new MongoClient(settings.ConnectionString);

            // Configurando nome do banco de dados
            var database = client.GetDatabase(settings.DatabaseName);

            // Recupera a coleção de eventos
            _eventos = database.GetCollection<EventoDomain>(settings.EventosCollectionName);
        }

        public void Create(EventoDomain evento)
        {
            try
            {
                _eventos.InsertOne(evento);
            }
            catch (Exception ex)
            {
                new Exception(ex.Message);
            }
        }

        public EventoDomain Get(string id)
        {
            return _eventos.Find<EventoDomain>(x => x.Id == id).FirstOrDefault();
        }

        public List<EventoDomain> GetAll()
        {
            return _eventos.AsQueryable<EventoDomain>().ToList();
        }

        public void Remove(string id)
        {
            try
            {
                _eventos.DeleteOne(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(string id, EventoDomain evento)
        {
            try
            {
                _eventos.ReplaceOne(x => x.Id == id, evento);
            }
            catch (Exception ex)
            {
               throw new Exception(ex.Message);
            }
        }
    }
}
