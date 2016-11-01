using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Atletas;
using Cronometrage.WPF.View.Eventos;
using Cronometrage.WPF.View.Faixas;
using Cronometrage.WPF.View.Modalidades;
using Cronometrage.WPF.ViewModel.Atletas;
using Cronometrage.WPF.ViewModel.Eventos;
using Cronometrage.WPF.ViewModel.Faixas;
using Cronometrage.WPF.ViewModel.Modalidades;
using Cronometragem.NH.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        private string nome;
        public string Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                this.nome = value;
                OnPropertyChanged("Nome");
            }
        }

        private ObservableCollection<Evento> eventos;

        //private ObservableCollection<Modalidade> modalidades;

        //private ObservableCollection<Faixa> faixas;

        //private ObservableCollection<Atleta> atletas;

        public ICommand EventoViewCommand { get; set; }

        public ICommand GerenciarEventoCommand { get; set; }

        public ICommand ModalidadeCommand { get; set; }

        public ICommand GerenciarModalidadeCommand { get; set; }

        public ICommand FaixaCommand { get; set; }

        public ICommand GerenciarFaixaCommand { get; set; }

        public ICommand AtletaCommand { get; set; }

        public ICommand GerenciarAtletaCommand { get; set; }

        public MainWindowViewModel()
        {
            eventos = new ObservableCollection<Evento>();
            //modalidades = new ObservableCollection<Modalidade>();
            //faixas = new ObservableCollection<Faixa>();
            //atletas = new ObservableCollection<Atleta>();

            #region Evento
            this.EventoViewCommand = new Command(p =>
            {
                var view = new EventoView();
                var viewModel = new EventoViewModel();

                view.DataContext = viewModel;
                viewModel.view = view;

                var evento = viewModel.Inserir();
                if (evento != null)
                {
                    //if (ConfigDB.Instance.EventoDAO.Inserir(evento))
                    //{
                    //    MessageBox.Show("Evento Inserido!");
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Deu erro na treta mano!");
                    //}
                }
            });

            this.GerenciarEventoCommand = new Command((p) =>
            {
                var view = new GerenciarEventoView();
                var viewModel = new GerenciarEventoViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                viewModel.Exibir(eventos);
            });
            #endregion
            #region Modalidade
            this.ModalidadeCommand = new Command((p) =>
            {
                var view = new ModalidadeView();
                var viewModel = new ModalidadeViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                //this.modalidades.Add(viewModel.Inserir());
            });

            this.GerenciarModalidadeCommand = new Command((p) =>
            {
                var view = new GerenciarModalidadeView();
                var viewModel = new GerenciarModalidadeViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                //viewModel.Exibir(modalidades);
            });
            #endregion
            #region Faixa
            FaixaCommand = new Command((p) =>
            {
                var view = new FaixaView();
                var viewModel = new FaixaViewModel();
                viewModel.View = view;
                view.DataContext = viewModel;

                //this.faixas.Add(viewModel.Inserir());
            });

            GerenciarFaixaCommand = new Command((p) =>
            {
                var view = new GerenciarFaixaView();
                var viewModel = new GerenciarFaixaViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                //viewModel.Exibir(faixas);
            });
            #endregion
            #region Atleta
            AtletaCommand = new Command((p) =>
            {
                var view = new AtletaView();
                var viewModel = new AtletaViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                //atletas.Add(viewModel.Inserir());
            });

            GerenciarAtletaCommand = new Command((p) =>
            {
                var view = new GerenciarAtletaView();
                var viewModel = new GerenciarAtletaViewModel();

                viewModel.View = view;
                view.DataContext = viewModel;

                //viewModel.Exibir(atletas);
            });
            #endregion
        }
    }
}
