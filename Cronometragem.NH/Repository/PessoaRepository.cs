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
    public class PessoaRepository
    {
        private ISession session = null;

        public PessoaRepository(ISession session)
        {
            this.session = session;
        }
        public IList<Pessoa> GetAll()
        {
            try
            {
                var pessoas = this.session.CreateCriteria<Pessoa>().List<Pessoa>();
                return pessoas;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void Gravar(Pessoa pessoa)
        {
            try
            {
                var transaction = this.session.BeginTransaction();

                this.session.SaveOrUpdate(pessoa);

                transaction.Commit();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
