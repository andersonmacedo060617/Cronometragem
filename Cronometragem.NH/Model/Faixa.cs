using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.NH.Model
{
    public class Faixa
    {

        public virtual int Id { get; set; }
        [Range(minimum:10, maximum:120)]
        public virtual int Min { get; set; }
        public virtual int Max { get; set; }
        public virtual Evento Evento { get; set; }
        public virtual String Descricao {
            get
            {
                return "Sub" + Max + " (" + Min + "-" + Max + ")";
            }
        }

    }

    public class FaixaMap : ClassMapping<Faixa>
    {
        public FaixaMap()
        {
            Id<int>(x => x.Id, m => m.Generator(Generators.Identity));

            Property<int>(x => x.Min);
            Property<int>(x => x.Max);

            ManyToOne<Evento>(x => x.Evento, m => m.Column("idEvento"));
        }
        
    }
}
