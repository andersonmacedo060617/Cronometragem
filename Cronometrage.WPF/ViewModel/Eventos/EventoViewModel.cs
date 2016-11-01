using Cronometrage.WPF.Property;
using Cronometrage.WPF.View.Eventos;
using Cronometragem.NH.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronometrage.WPF.ViewModel.Eventos
{
    public class EventoViewModel : NotifyPropertyBase
    {
        public EventoView view { get; set; }

        public ICommand GravarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        private Evento evento;

        public EventoViewModel()
        {
            this.evento = null;
            this.Data = DateTime.Now;

            this.CancelarCommand = new Command((p) =>
            {
                if (this.evento != null)
                    this.evento.Id = 0;
                else
                    this.evento = null;

                this.view.Close();
            });

            this.GravarCommand = new Command((p) =>
            {
                if (this.evento == null)
                {
                    this.evento = new Evento()
                    {
                        Nome = this.nome,
                        Data = this.data
                    };
                }
                else
                {
                    this.evento.Nome = this.Nome;
                    this.evento.Data = this.Data;
                }               

                this.view.Close();
            });
        }

        public Evento Inserir()
        {
            this.view.ShowDialog();
            return this.evento;
        }

        public void Alterar(Evento evento)
        {
            this.evento = evento;
            this.Nome = evento.Nome;
            this.Data = evento.Data;

            this.view.ShowDialog();
        }

        private String nome;
        public String Nome
        {
            get
            {
                return this.nome;
            }
            set
            {
                if (this.nome == value)
                    return;

                this.nome = value;
                OnPropertyChanged("Nome");
            }
        }

        private DateTime data;
        public DateTime Data
        {
            get
            {
                return this.data;
            }
            set
            {
                if (this.data == value)
                    return;

                this.data = value;
                OnPropertyChanged("Data");
            }
        }

    }
}
