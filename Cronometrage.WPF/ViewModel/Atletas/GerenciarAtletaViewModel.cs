using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Atletas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel.Atletas
{
    public class GerenciarAtletaViewModel : NotifyPropertyBase
    {
        public GerenciarAtletaView View { get; set; }

        //private ObservableCollection<Atleta> atletas { get; set; }
        //public ObservableCollection<Atleta> Atletas
        //{
        //    get
        //    {
        //        return this.atletas;
        //    }
        //    set
        //    {
        //        if (this.atletas != value)
        //        {
        //            this.atletas = value;
        //            OnPropertyChanged("Atletas");
        //        }
        //    }
        //}

        //public Atleta AtletaSelecionado { get; set; }

        public ICommand ExcluirAtletaCommand { get; set; }

        public GerenciarAtletaViewModel()
        {
            ExcluirAtletaCommand = new Command((p) =>
            {
                //if (AtletaSelecionado != null)
                //    this.Atletas.Remove(AtletaSelecionado);
            });
        }

        //public void Exibir(ObservableCollection<Atleta> atletas)
        //{
        //    this.Atletas = atletas;
        //    this.View.ShowDialog();
        //}
    }
}
