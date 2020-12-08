using Nyous.WebApi.NoSQL.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.WebApi.NoSQL.Interfaces
{
    public interface IEventosRepository
    {
        void Create(EventoDomain evento);
        List<EventoDomain> GetAll();

        EventoDomain Get(string id);

        void Update(string id, EventoDomain evento);

        void Remove(string id);
    }
}
