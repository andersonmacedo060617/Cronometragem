using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Eventos;
using Cronometragem.NH.Config;
using Cronometragem.NH.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel.Eventos
{
    public class GerenciarEventoViewModel : NotifyPropertyBase
    {
        public GerenciarEventoView View { get; set; }

        public ICommand ExcluirEventoCommmand { get; set; }
        public ICommand AlterarEventoCommmand { get; set; }
        public ICommand BuscarCommmand { get; set; }

        private List<Evento> eventos2;

        private ObservableCollection<Evento> eventos;

        public ObservableCollection<Evento> Eventos
        {
            get
            {
                return this.eventos;
            }
            set
            {
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
                this.eventoSelecionado = value;
                OnPropertyChanged("EventoSelecionado");
            }
        }

        private String busca;
        public String Busca
        {
            get
            {
                return this.busca;
            }
            set
            {
                if (this.busca == value)
                    return;

                this.busca = value;
                OnPropertyChanged("Busca");
            }
        }

        public GerenciarEventoViewModel()
        {
            ExcluirEventoCommmand = new Command((p) => 
            {
                if (this.eventoSelecionado != null)
                {
                    //ConfigDB.Instance.EventoDAO.Excluir(this.eventoSelecionado.Id);
                    //var eventos = ConfigDB.Instance.EventoDAO.GetAll();
                    this.Eventos = new ObservableCollection<Evento>(eventos);
                }                    
            });

            AlterarEventoCommmand = new Command((p) =>
            {
                if (this.eventoSelecionado != null)
                {
                    var view = new EventoView();
                    var viewModel = new EventoViewModel();

                    view.DataContext = viewModel;
                    viewModel.view = view;

                    viewModel.Alterar(this.eventoSelecionado);

                    if (this.eventoSelecionado.Id != 0)
                    {
                        //ConfigDB.Instance.EventoDAO.Alterar(this.eventoSelecionado);
                    }

                    //var eventos = ConfigDB.Instance.EventoDAO.GetAll();
                    //this.Eventos = new ObservableCollection<Evento>(eventos);
                }   
            });

            this.BuscarCommmand = new Command((p) =>
            {
                //var eventos = ConfigDB.Instance.EventoDAO.GetAll();
                //this.Eventos = new ObservableCollection<Evento>(eventos);
                //if (this.busca != "")
                //{
                //    var filtroEventos = eventos.Where(qqCoisa => qqCoisa.Nome.Contains(this.busca)).ToList();
                //    this.Eventos = new ObservableCollection<Evento>(filtroEventos);
                //}
            });
        }

        public void Exibir(ObservableCollection<Evento> eventos)
        {
            var cfg = new ConfigDB();
            //this.Eventos = new ObservableCollection<Evento>(
            //    ConfigDB.Instance.EventoDAO.GetAll());
            this.View.ShowDialog();
        }
    }
}
