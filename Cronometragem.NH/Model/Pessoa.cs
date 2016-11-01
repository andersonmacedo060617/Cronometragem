using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.NH.Model
{
    public class Pessoa
    {
        public virtual long Id { get; set; }
        public virtual String Nome { get; set; }
        public virtual DateTime DtNascimento { get; set; }
        public virtual Boolean Sexo { get; set; }
        public virtual String Telefone { get; set; }
        public virtual String Email { get; set; }

        public virtual IList<Usuario> Usuarios { get; set; }

        public Pessoa()
        {
            this.Usuarios = new List<Usuario>();
        }
    }

    public class PessoaMAp : ClassMapping<Pessoa>
    {
        public PessoaMAp()
        {
            Id<long>(x => x.Id, m => m.Generator(Generators.Identity));

            Property<String>(x => x.Nome);
            Property<DateTime>(x => x.DtNascimento);
            Property<Boolean>(x => x.Sexo);
            Property<String>(x => x.Telefone);
            Property<String>(x => x.Email);

            Bag<Usuario>(x => x.Usuarios, m =>
            {
                m.Cascade(Cascade.All);
                m.Lazy (CollectionLazy.Lazy);
                m.Inverse(true);
                m.Key(k => k.Column("idPessoa"));
            },
            o => o.OneToMany());
        }
    }
}
