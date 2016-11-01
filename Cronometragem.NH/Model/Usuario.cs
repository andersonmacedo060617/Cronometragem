using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cronometragem.NH.Model
{
    public class Usuario
    {
        public virtual long Id { get; set; }

        [Remote("VerificarLogin", "Usuario", ErrorMessage = "Este Usuário já existe.")]
        public virtual String Login { get; set; }
        [Required(ErrorMessage = "Senha Obrigatória")]
        public virtual String Senha { get; set; }

        public virtual Pessoa Pessoa { get; set; }


        public class UsuarioMap : ClassMapping<Usuario>
        {
            public UsuarioMap()
            {
                Id<long>(x => x.Id, m => m.Generator(Generators.Identity));

                Property<String>(x => x.Login);
                Property<String>(x => x.Senha);

                ManyToOne<Pessoa>(x => x.Pessoa, m =>
                {
                    m.Column("idPessoa");
                });
            }
        }
    }
}
