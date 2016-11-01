using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Atletas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometrage.WPF.ViewModel.Atletas
{
    public class AtletaViewModel : NotifyPropertyBase
    {
        public AtletaView View { get; set; }

        public AtletaViewModel()
        {
        }

        //public Atleta Inserir()
        //{
        //    this.View.ShowDialog();
        //    return new Atleta();
        //}
    }
}
