using System;
using System.Collections;
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

        //Update dos dados do cliente
        public void EditarCli(Cliente cli, string cod) {
            //convertendo o parametro
            int codCli;

            codCli = Convert.ToInt32(cod);

            //comando sql alterando o cliente
            MySqlCommand cmd = new MySqlCommand("UPDATE cliente SET NOME_CLIENTE=@nome, CPF_CNPJ=@cpf, CNH_CLIENTE=@cnh WHERE COD_CLIENTE = " + codCli, con.MyConectorBd());

            //add parametro para o update
            cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = cli.nomeCli;
            cmd.Parameters.Add("@cpf", MySqlDbType.VarChar).Value = cli.cpfCli;
            cmd.Parameters.Add("@cnh", MySqlDbType.VarChar).Value = cli.cnhCli;

            cmd.ExecuteNonQuery();

            //alterando o telefone
            MySqlCommand slct = new MySqlCommand("SELECT cli.COD_TELL_FK, cli.COD_ENDERECO_FK, edn.COD_ENDERECO, tell.COD_TELL FROM Cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL INNER JOIN endereco AS edn ON cli.COD_ENDERECO_FK = edn.COD_ENDERECO WHERE cli.COD_CLIENTE = " + codCli, con.MyConectorBd());

            MySqlDataReader leitor;

            leitor = slct.ExecuteReader();

            //acessando o select
            while (leitor.Read()) {

                cli.codTellCli = Convert.ToInt32(leitor["COD_TELL"]);
                cli.codEndCli = Convert.ToInt32(leitor["COD_ENDERECO"]);

            }

            con.MyCloseBd();    //fechando a conexao

            //fazendo o Update
            MySqlCommand updt = new MySqlCommand("UPDATE telefone SET TELL1=@tellfixo, TELL2=@cell WHERE COD_TELL = " + cli.codTellCli, con.MyConectorBd());

            //add parametro para o update
            updt.Parameters.Add("@tellFixo", MySqlDbType.VarChar).Value = cli.tellCli;
            updt.Parameters.Add("@cell", MySqlDbType.VarChar).Value = cli.tell2Cli;

            updt.ExecuteNonQuery();

            con.MyCloseBd();    //fechando a conexao

            //fazendo o update
            MySqlCommand updtEdn = new MySqlCommand("UPDATE endereco SET LOGRADURO=@rua, NUMERO=@num, BAIRRO=@bairro, CEP=@cep, CIDADE=@cidade WHERE COD_ENDERECO = " + cli.codEndCli, con.MyConectorBd());

            //add parametro para o update
            updtEdn.Parameters.Add("@rua", MySqlDbType.VarChar).Value = cli.rualgCli;
            updtEdn.Parameters.Add("@num", MySqlDbType.VarChar).Value = cli.numCli;
            updtEdn.Parameters.Add("@bairro", MySqlDbType.VarChar).Value = cli.bairroCli;
            updtEdn.Parameters.Add("@cep", MySqlDbType.VarChar).Value = cli.cepCli;
            updtEdn.Parameters.Add("@cidade", MySqlDbType.VarChar).Value = cli.tell2Cli;

            updtEdn.ExecuteNonQuery();

        }

        //Delete Cliente
        public void DeleteCli(string cod) {
            //variavel local e convertendo para int
            int codCli;
            int codTell = 0;
            int codEnd = 0;

            codCli = Convert.ToInt32(cod);

            //comando sql
            //pegando os codigos
            MySqlCommand slct = new MySqlCommand("SELECT edn.COD_ENDERECO, tell.COD_TELL FROM Cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL INNER JOIN endereco AS edn ON cli.COD_ENDERECO_FK = edn.COD_ENDERECO WHERE cli.COD_CLIENTE = " + codCli, con.MyConectorBd());

            MySqlDataReader leitor;

            leitor = slct.ExecuteReader();

            while (leitor.Read()) {

                codTell = Convert.ToInt32(leitor["COD_TELL"]);
                codEnd =  Convert.ToInt32(leitor["COD_ENDERECO"]);

            }

            con.MyCloseBd(); //fechando a conexao

            //fazendo o delete telefone
            MySqlCommand delTell = new MySqlCommand("DELETE FROM telefone WHERE COD_TELL = " + codTell, con.MyConectorBd());

            delTell.ExecuteNonQuery();

            //fazendo o delete endereco
            MySqlCommand delEnd = new MySqlCommand("DELETE FROM endereco WHERE COD_ENDERECO = " + codEnd, con.MyConectorBd());

            delEnd.ExecuteNonQuery();

            //fazendo o delete endereco
            MySqlCommand delCli = new MySqlCommand("DELETE FROM cliente WHERE COD_CLIENTE = " + codCli, con.MyConectorBd());

            delEnd.ExecuteNonQuery();

            con.MyCloseBd();
        }

        //Consulta dos Cliente
        /*
        *
        * aqui estou fazendo um metodo que retorna
        * list<objeto>
        * 
        **/
        public static List<Cliente> consultaCli() {

            //variaveis locais
            List<Cliente> listaClientes = new List<Cliente>();


            //Cliente cli = new Cliente();
            Conexao con = new Conexao();

            //comando sql
            MySqlCommand cmdSlct = new MySqlCommand("SELECT cli.NOME_CLIENTE, cli.CPF_CNPJ, cli.CNH_CLIENTE, tell.TELL1, tell.TELL2, cli.COD_CLIENTE FROM cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL", con.MyConectorBd());

            MySqlDataReader leitor; //preparando o select

            leitor = cmdSlct.ExecuteReader();   //executando no banco

            //verificando se vem algo

            //passando por todos as busca e colocando no list<objeto>
            while (leitor.Read()) {

                listaClientes.Add(new Cliente
                {
                    codCli = leitor.GetString("COD_CLIENTE"),
                    nomeCli = leitor.GetString("NOME_CLIENTE"),
                    cpfCli = leitor.GetString("CPF_CNPJ"),
                    cnhCli = leitor.GetString("CNH_CLIENTE"),
                    tellCli = leitor.GetString("TELL1"),
                    tell2Cli = leitor.GetString("TELL2")
                });

            }

            con.MyCloseBd();

            return listaClientes;

        }

        /*
         * 
         *Detalhes do cliente 
         * 
         * 
         * */
        public List<string> detalheCli(string cod) {
            //criando a list local
            List<string> listaClientes = new List<string>();
            int codDtlhs;

            //comando sql
            codDtlhs = Convert.ToInt32(cod);
            MySqlCommand cmd = new MySqlCommand("SELECT cli.COD_CLIENTE,cli.NOME_CLIENTE, cli.CPF_CNPJ, cli.CNH_CLIENTE, edn.LOGRADURO, NUMERO, BAIRRO, CEP, CIDADE, ESTADO, tell.TELL2, tell.TELL1 FROM cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL INNER JOIN endereco AS edn  ON cli.COD_ENDERECO_FK = edn.COD_ENDERECO WHERE cli.COD_CLIENTE = " + codDtlhs, con.MyConectorBd());

            MySqlDataReader leitor; //preparando o select

            leitor = cmd.ExecuteReader();   //executando no banco


            //passando por todos as busca e colocando no list<objeto>
            while (leitor.Read())
            {
                listaClientes.Add(leitor.GetString("COD_CLIENTE"));
                listaClientes.Add(leitor.GetString("NOME_CLIENTE"));
                listaClientes.Add(leitor.GetString("CPF_CNPJ"));
                listaClientes.Add(leitor.GetString("CNH_CLIENTE"));
                listaClientes.Add(leitor.GetString("LOGRADURO"));
                listaClientes.Add(leitor.GetString("NUMERO"));
                listaClientes.Add(leitor.GetString("BAIRRO"));
                //listaClientes.Add(leitor.GetString("CEP"));
                listaClientes.Add(leitor.GetString("CIDADE"));
                //listaClientes.Add(leitor.GetString("ESTADO"));
                listaClientes.Add(leitor.GetString("TELL1"));
                listaClientes.Add(leitor.GetString("TELL2"));

            }

            con.MyCloseBd();

            return listaClientes;

        }

        public List<Cliente> buscaCli(string busc) {

            //variaveis locais
            List<Cliente> listaClientes = new List<Cliente>();

            //comando sql
            MySqlCommand slct = new MySqlCommand("SELECT cli.NOME_CLIENTE, cli.CPF_CNPJ, cli.CNH_CLIENTE, tell.TELL1, tell.TELL2, cli.COD_CLIENTE FROM cliente AS cli INNER JOIN telefone AS tell ON cli.COD_TELL_FK = tell.COD_TELL WHERE NOME_CLIENTE LIKE '%" + busc + "%'", con.MyConectorBd());

            //preparando o comando
            MySqlDataReader leitor;

            leitor = slct.ExecuteReader();

            //guardando o resultado
            while (leitor.Read()) {

                listaClientes.Add(new Cliente
                {
                    codCli = leitor.GetString("COD_CLIENTE"),
                    nomeCli = leitor.GetString("NOME_CLIENTE"),
                    cpfCli = leitor.GetString("CPF_CNPJ"),
                    cnhCli = leitor.GetString("CNH_CLIENTE"),
                    tellCli = leitor.GetString("TELL1"),
                    tell2Cli = leitor.GetString("TELL2")
                });

            }

            con.MyCloseBd();

            return listaClientes;

        }
    }
}