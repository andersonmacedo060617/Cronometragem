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
    public class Evento
    {
        public virtual int Id { get; set; }

        public virtual string Nome { get; set; }

        [DataType(dataType: DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}", NullDisplayText = "Data Invalida")]
        public virtual DateTime Data { get; set; }

        public virtual String Local { get; set; }

        [DataType(dataType: DataType.Time)]
        public virtual TimeSpan Largada { get; set; }

        public virtual String Obs { get; set; }
        public virtual IList<Faixa> Faixas { get; set; }

        public Evento()
        {
            this.Faixas = new List<Faixa>();
        }
    }

    public class EventoMap : ClassMapping<Evento>
    {
        public EventoMap()
        {
            Table("Evento");

            Id<int>(x => x.Id, m =>
            {
                m.Generator(Generators.Identity);
            });

            Property<String>(x => x.Nome);
            Property<DateTime>(x => x.Data);
            Property<String>(x => x.Local);
            Property<TimeSpan>(x => x.Largada);
            Property<String>(x => x.Obs);

            Bag<Faixa>(
                x=>x.Faixas,
                m =>
                {
                    m.Lazy(CollectionLazy.Lazy);
                    m.Cascade(Cascade.All);
                    m.Inverse(true);
                    m.Key(k => k.Column("idEvento"));
                },
                r=>r.OneToMany()
                );
        }
    }
}
