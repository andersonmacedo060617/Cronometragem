using Cronometragem.Model.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.Model.Config
{
    public class ConfigDB
    {
        public static string StringConexao =  
            "Persist Security Info=False;server=localhost;port=3306;"+
            "database=cronometragem;uid=root;pwd=aluno";

        private static ConfigDB _instance = null;
        public static ConfigDB Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigDB();
                }

                return _instance;
            }
        }

        public EventoDAO EventoDAO { get; set; }

        private ConfigDB()
        {
            if (Conexao())
            {
                this.EventoDAO = new EventoDAO(Connection);                
            }
        }

        private MySqlConnection Connection;

        private bool Conexao()
        {
            Connection = new MySqlConnection(StringConexao);
            try
            {
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Connection.Close();
                return false;
            }
        }
    }
}
