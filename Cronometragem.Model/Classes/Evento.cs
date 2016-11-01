using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cronometragem.Model.Classes
{
    public class Evento
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        public decimal Preco { get; set; }
    }

    public class EventoDAO
    {
        private MySqlConnection conexao;

        public EventoDAO(MySqlConnection conexao)
        {
            this.conexao = conexao;
        }

        public bool Inserir(Evento evento)
        {
            try
            {
                var sql = "INSERT INTO `cronometragem`.`evento` \n"+
                            "(`nome`, \n"+
                            "`data`, \n"+
                            "`preco`) \n"+
                            "VALUES \n"+
                            "(@nome, \n"+
                            "@data, \n"+
                            "@preco);";

                if (this.conexao.State == ConnectionState.Closed)
                {
                    this.conexao.Open();
                }

                var cmd = new MySqlCommand(sql, this.conexao);
                cmd.Parameters.Add("@nome", evento.Nome);
                cmd.Parameters.Add("@data", evento.Data);
                cmd.Parameters.Add("@preco", evento.Preco);

                cmd.ExecuteNonQuery();

                return true;
            }catch(Exception ex){
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Alterar(Evento evento)
        {
            try
            {
                var sql = "UPDATE `cronometragem`.`evento` \n"+
                          "  SET \n"+
                          "  `nome` = @nome, \n"+
                          "  `data` = @data, \n"+
                          "  `preco` = @preco \n"+
                          "  WHERE `id` = @id;";

                if (this.conexao.State == ConnectionState.Closed)
                {
                    this.conexao.Open();
                }

                var cmd = new MySqlCommand(sql, this.conexao);
                cmd.Parameters.Add("@nome", evento.Nome);
                cmd.Parameters.Add("@data", evento.Data);
                cmd.Parameters.Add("@preco", evento.Preco);
                cmd.Parameters.Add("@id", evento.Id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Excluir(int id)
        {
            try
            {
                var sql = "DELETE FROM `cronometragem`.`evento` WHERE id = @id;";

                if (this.conexao.State == ConnectionState.Closed)
                {
                    this.conexao.Open();
                }

                var cmd = new MySqlCommand(sql, this.conexao);
                cmd.Parameters.Add("@id", id);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Evento> GetAll()
        {
            var eventos = new List<Evento>();

            var sql = "Select * from evento";
            var ds = new DataSet();
            var query = new MySqlDataAdapter(sql, this.conexao);
            query.Fill(ds);

            foreach(var linha in ds.Tables[0].AsEnumerable().ToList()){
                var evento = new Evento()
                {
                    Id = Convert.ToInt32(linha["id"]),
                    Nome = linha["nome"].ToString(),
                    Preco = Convert.ToDecimal(linha["preco"]),
                    Data = Convert.ToDateTime(linha["data"])
                };

                eventos.Add(evento);
            }

            return eventos;
        }
    }
}
