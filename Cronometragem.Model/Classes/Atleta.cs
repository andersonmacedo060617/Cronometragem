using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.Model.Classes
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Equipe { get; set; }
        public bool Sexo { get; set; }
        public DateTime DtNascimento { get; set; }
        public Faixa Faixa { get; set; }
    }
}
