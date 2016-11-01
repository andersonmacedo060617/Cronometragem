using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Faixas;
using Cronometragem.NH.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometrage.WPF.ViewModel.Faixas
{
    public class FaixaViewModel : NotifyPropertyBase
    {
        public FaixaView View { get; set; }

        public FaixaViewModel()
        {
            this.eventos = new ObservableCollection<Evento>();
        }

        //public Faixa Inserir()
        //{
        //    this.Eventos = new ObservableCollection<Evento>(
        //        ConfigDB.Instance.EventoDAO.GetAll()
        //    );

        //    this.View.ShowDialog();
        //    return new Faixa();
        //}

        private ObservableCollection<Evento> eventos;
        public ObservableCollection<Evento> Eventos
        {
            get
            {
                return this.eventos;
            }
            set
            {
                if (this.eventos == value)
                    return;

                this.eventos = value;
                OnPropertyChanged("Eventos");
            }
        }

        private Evento eventoSelecionado;
        public Evento EventoSelecionado
        {
            get
            {
                return this.eventoSelecionado;
            }
            set
            {
                if (this.eventoSelecionado == value)
                    return;

                this.eventoSelecionado = value;
                OnPropertyChanged("EventoSelecionado");
            }
        }
    }
}
