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
            //variaveis locais
            //int codTell, codEnd;
            //telefone Cliente
            /*MySqlCommand cmd = new MySqlCommand("INSERT INTO telefone(TELL1, TELL2)VALUES('4002 - 8922','')", con.MyConectorBd());    //commando do banco pra inserir telefone
            cmd.ExecuteNonQuery();

            //endereco Cliente
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO endereco(LOGRADURO, NUMERO, BAIRRO, CEP, CIDADE, ESTADO)VALUES('Rua tarantino santana','15', 'elitropolis','12365-456', 'elipes', 'elapezes')", con.MyConectorBd());
            cmd1.ExecuteNonQuery();*/

            //busca tel e endereco
            /*MySqlCommand cmdTell = new MySqlCommand("SELECT COD_TELL FROM TELEFONE WHERE COD_TELL = 3", con.MyConectorBd());    //busca cmdTell
            MySqlCommand cmdEnd = new MySqlCommand("SELECT COD_ENDERECO FROM endereco WHERE COD_ENDERECO = 4;", con.MyConectorBd());   //busca cmdEnd

            //buscando tell
            MySqlDataReader leitorTell; //preparando o comando sql

            leitorTell = cmdTell.ExecuteReader(); //executando sql

            if (leitorTell.HasRows) {   //verificando se veio algo

                while (leitorTell.Read()) { //lendo o resultado

                    codTell = Convert.ToInt32(leitorTell["COD_TELL"]);
                    
                }

            }

            //busca end
            MySqlDataReader leitorEnd; //preparando o comando sql

            leitorEnd = cmdEnd.ExecuteReader(); //executando sql

            if (leitorEnd.HasRows)
            {   //verificando se veio algo

                while (leitorEnd.Read())
                { //lendo o resultado

                    codEnd = Convert.ToInt32(leitorEnd["COD_ENDERECO"]);

                }

            }*/

            //cliente Cliente
            MySqlCommand cmd2 = new MySqlCommand("INSERT INTO cliente(NOME_CLIENTE, CPF_CNPJ, CNH_CLIENTE, COD_TELL_FK, COD_ENDERECO_FK)VALUES('ana julia','111.333.258-79','0000000', 3, 4)", con.MyConectorBd());
            cmd2.ExecuteNonQuery();

            con.MyCloseBd();
        }

        public DataTable consultaCli() {

            MySqlCommand cmd = new MySqlCommand("SELECT COD_CLIENTE, NOME_CLIENTE, CPF_CNPJ, CNH_CLIENTE FROM cliente", con.MyConectorBd()); //fazendo a consulta
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable consultClint = new DataTable();
            data.Fill(consultClint);
            con.MyCloseBd();
            return consultClint;

        }

        public DataTable buscCli(Cliente clit) {

            //MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente WHERE COD_CLIENTE = @cod", con.MyConectorBd());
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM cliente WHERE COD_CLIENTE = @cod", con.MyConectorBd());
            cmd.Parameters.AddWithValue("@cod", clit.codCli);   //adicionando o parametro do codigo cliente
            MySqlDataAdapter data = new MySqlDataAdapter(cmd);
            DataTable consultClint = new DataTable();
            data.Fill(consultClint);
            con.MyCloseBd();

            return consultClint;

        }
    }
}