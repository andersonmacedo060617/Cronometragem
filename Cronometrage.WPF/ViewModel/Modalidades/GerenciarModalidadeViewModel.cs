using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Modalidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel.Modalidades
{
    public class GerenciarModalidadeViewModel : NotifyPropertyBase
    {
        public GerenciarModalidadeView View { get; set; }

        //private ObservableCollection<Modalidade> modalidades { get; set; }

        //public ObservableCollection<Modalidade> Modalidades
        //{
        //    get
        //    {
        //        return this.modalidades;
        //    }
        //    set
        //    {
        //        if (modalidades != value)
        //        {
        //            this.modalidades = value;
        //            OnPropertyChanged("Modalidades");
        //        }
        //    }
        //}

        //public Modalidade ModalidadeSelecionada { get; set; }

        public ICommand ExcluirModalidadeCommand { get; set; }

        public GerenciarModalidadeViewModel()
        {
            ExcluirModalidadeCommand = new Command(p =>
            {
                //if (this.ModalidadeSelecionada != null)
                //    this.Modalidades.Remove(ModalidadeSelecionada);
            });
        }

        //public void Exibir(ObservableCollection<Modalidade> modalidades)
        //{
        //    this.Modalidades = modalidades;
        //    this.View.ShowDialog();
        //}
    }
}
