using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.Model.Classes
{
    public class Faixa
    {
        public int Id { get; set; }
        public String Descricao { 
            get{
                return this.IdadeMin + " - " + this.IdadeMax;}  
        }
        public int IdadeMin { get; set; }
        public int IdadeMax { get; set; }
        public int Premiacao { get; set; }        
        public List<Atleta> Atletas { get; set; }
        public Evento Evento { get; set; }

        public Faixa()
        {
            this.Atletas = new List<Atleta>();
        }
    }
}
