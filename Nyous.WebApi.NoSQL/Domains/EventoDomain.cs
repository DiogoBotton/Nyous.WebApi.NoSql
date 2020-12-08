using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nyous.WebApi.NoSQL.Domains
{
    public class EventoDomain : BaseDomain
    {
        public string Nome { get; set; }
        public string UrlImagem { get; set; }
        public string Link { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
    }
}
