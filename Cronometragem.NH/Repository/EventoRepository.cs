using Cronometragem.NH.Model;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cronometragem.NH.Repository
{
    public class EventoRepository
    {
        private ISession session = null;

        public EventoRepository(ISession session)
        {
            this.session = session;
        }
        public IList<Evento> GetAll()
        {
            try
            {
                var eventos = this.session.CreateCriteria<Evento>().List<Evento>();
                return eventos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Gravar(Evento evento)
        {
            try
            {
                session.Clear();
                var transaction = this.session.BeginTransaction();

                this.session.SaveOrUpdate(evento);

                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
