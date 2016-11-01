using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Modalidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometrage.WPF.ViewModel.Modalidades
{
    public class ModalidadeViewModel : NotifyPropertyBase
    {
        public ModalidadeView View { get; set; }

        public ModalidadeViewModel()
        {
        }

        //public Modalidade Inserir()
        //{
        //    this.View.ShowDialog();
        //    return new Modalidade();
        //}
    }
}
