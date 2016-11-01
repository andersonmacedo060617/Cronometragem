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
    public class UsuarioRepository
    {
        private ISession session = null;

        public UsuarioRepository(ISession session)
        {
            this.session = session;
        }
        public IList<Usuario> GetAll()
        {
            try
            {
                var usuarios = this.session.CreateCriteria<Usuario>().List<Usuario>();
                return usuarios;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
