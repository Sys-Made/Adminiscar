using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Adminiscar.Models;
using MySql.Data.MySqlClient;

namespace Adminiscar.Dal
{
    /**
     * 
     * aqui vai ser a função cadastro e consulta do cliente
     * 
     * */
    public class acoesCli
    {

        Conexao con = new Conexao();    //inicioando o novo objeto da conexao

        public void cadastroCli(Cliente cliente) {
            //telefone Cliente
            MySqlCommand cmd = new MySqlCommand("INSERT INTO telefone(TELL1, TELL2)VALUES(@tell, @tell1)", con.MyConectorBd());    //commando do banco pra inserir telefone
            cmd.Parameters.Add("@tell", MySqlDbType.VarChar).Value = cliente.tellCli;
            cmd.Parameters.Add("@tell1", MySqlDbType.VarChar).Value = cliente.tell2Cli;
            cmd.ExecuteNonQuery();

            //endereco Cliente
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO endereco(LOGRADURO, NUMERO, BAIRRO, CEP, CIDADE, ESTADO)VALUES(@rua, @numero, @bairro, @cep, @cidade, @estado)", con.MyConectorBd());
            cmd1.Parameters.Add("@rua", MySqlDbType.VarChar).Value = cliente.rualgCli;
            cmd1.Parameters.Add("@numero", MySqlDbType.VarChar).Value = cliente.numCli;
            cmd1.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = cliente.bairroCli;
            cmd1.Parameters.Add("@cep", MySqlDbType.VarChar).Value = cliente.cepCli;
            cmd1.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cliente.cidCli;
            cmd1.Parameters.Add("@estado", MySqlDbType.VarChar).Value = cliente.estCli;
            cmd1.ExecuteNonQuery();

            //busca tell
            MySqlCommand cmdTell = new MySqlCommand("SELECT MAX(COD_TELL) FROM telefone", con.MyConectorBd());    //busca cmdTell

            //buscando tell
            MySqlDataReader leitorTell; //preparando o comando sql

            leitorTell = cmdTell.ExecuteReader(); //executando sql

            if (leitorTell.HasRows) {   //verificando se veio algo

                while (leitorTell.Read()) { //lendo o resultado

                    cliente.codTellCli = Convert.ToInt32(leitorTell["MAX(COD_TELL)"]);
                    
                }

            }

            con.MyCloseBd(); //fechando a conexao

            //busca endereco
            MySqlCommand cmdEnd = new MySqlCommand("SELECT MAX(COD_ENDERECO) FROM endereco", con.MyConectorBd());   //busca cmdEnd

            //busca endereco
            MySqlDataReader leitorEnd; //preparando o comando sql

            leitorEnd = cmdEnd.ExecuteReader(); //executando sql

            if (leitorEnd.HasRows)
            {   //verificando se veio algo

                while (leitorEnd.Read())
                { //lendo o resultado

                    cliente.codEndCli = Convert.ToInt32(leitorEnd["MAX(COD_ENDERECO)"]);

                }

            }

            con.MyCloseBd(); //fechando a conexao

            //cliente Cliente
            MySqlCommand cmd2 = new MySqlCommand("INSERT INTO cliente(NOME_CLIENTE, CPF_CNPJ, CNH_CLIENTE, COD_TELL_FK, COD_ENDERECO_FK)VALUES(@nome, @cpfcnpj, @cnh, @codtell, @codend)", con.MyConectorBd());
            cmd2.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cliente.nomeCli;
            cmd2.Parameters.Add("@cpfcnpj", MySqlDbType.VarChar).Value = cliente.cpfCli;
            cmd2.Parameters.Add("@cnh", MySqlDbType.VarChar).Value = cliente.cnhCli;
            cmd2.Parameters.Add("@codtell", MySqlDbType.Int32).Value = cliente.codTellCli;
            cmd2.Parameters.Add("@codend", MySqlDbType.Int32).Value = cliente.codEndCli;
            cmd2.ExecuteNonQuery();

            con.MyCloseBd();
        }

        public DataTable consultaCli() {

            MySqlCommand cmd = new MySqlCommand("SELECT cli.NOME_CLIENTE, cli.CPF_CNPJ, cli.CNH_CLIENTE, tell.TELL1, tell.TELL2 FROM cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL", con.MyConectorBd()); //fazendo a consulta
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable consultClint = new DataTable();
            data.Fill(consultClint);
            con.MyCloseBd();
            return consultClint;

        }

        public DataTable buscCli(Cliente clit) {

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente WHERE COD_CLIENTE = @cod", con.MyConectorBd());  //comando sql copm a conexao
            cmd.Parameters.AddWithValue("@cod", clit.codCli);   //adicionando o parametro do codigo cliente
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable consultClint = new DataTable();
            data.Fill(consultClint);
            con.MyCloseBd();

            return consultClint;

        }
    }
}