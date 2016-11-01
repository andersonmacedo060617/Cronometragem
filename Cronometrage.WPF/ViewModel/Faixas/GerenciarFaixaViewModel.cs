using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Faixas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel.Faixas
{
    public class GerenciarFaixaViewModel : NotifyPropertyBase
    {
        public GerenciarFaixaView View { get; set; }

        //private ObservableCollection<Faixa> faixas { get; set; }
        //public ObservableCollection<Faixa> Faixas
        //{
        //    get
        //    {
        //        return this.faixas;
        //    }
        //    set
        //    {
        //        if(this.faixas != value)
        //        {
        //            this.faixas = value;
        //            OnPropertyChanged("Faixas");
        //        }
        //    }
        //}
        
        //public Faixa FaixaSelecionada { get; set; }

        public ICommand ExcluirFaixaCommand { get; set; }

        public GerenciarFaixaViewModel()
        {
            ExcluirFaixaCommand = new Command((p) =>
            {
                //if (FaixaSelecionada != null)
                //    this.Faixas.Remove(FaixaSelecionada);
            });
        }

        //public void Exibir(ObservableCollection<Faixa> faixas)
        //{
        //    this.Faixas = faixas;
        //    this.View.ShowDialog();
        //}
    }
}
