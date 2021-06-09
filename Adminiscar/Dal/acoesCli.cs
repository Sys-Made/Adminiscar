using System;
using System.Collections.Generic;
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

        public void cadastroCli(Cliente cadCliente) {

            //telefone Cliente
            /*MySqlCommand cmd = new MySqlCommand("INSERT INTO telefone(TELL1, TELL2)VALUES('4002 - 8922','')", con.MyConectorBd());    //commando do banco pra inserir telefone
            cmd.ExecuteNonQuery();*/

            //endereco Cliente
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO endereco(LOGRADURO, NUMERO, BAIRRO, CEP, CIDADE, ESTADO)VALUES('Rua tarantino santana','15', 'elitropolis','12365-456', 'elipes', 'elapezes')", con.MyConectorBd());
            cmd1.ExecuteNonQuery();

            //cliente Cliente
            con.MyCloseBd();
        }

    }
}