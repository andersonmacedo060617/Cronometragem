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
    

    public class FaixaRepository
    {
        private ISession session = null;

        public FaixaRepository(ISession session)
        {
            this.session = session;
        }
        public IList<Faixa> GetAll()
        {
            try
            {
                var faixas = this.session.CreateCriteria<Faixa>().List<Faixa>();
                return faixas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Gravar(Faixa faixa)
        {
            try
            {
                session.Clear();
                var transaction = this.session.BeginTransaction();

                this.session.SaveOrUpdate(faixa);

                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
