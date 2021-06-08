using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Adminiscar.Dal
{
    public class Conexao
    {
        //Fazendo a conexao do banco
        MySqlConnection conx = new MySqlConnection("Server=localhost;DataBase=bdadminiscar;User=root;pwd=40028922+pokpok"); //variavel com a conexao

        public static string msg; // mensagem de erro

        //conectando 
        public MySqlConnection MyConectorBd() {

            try
            {

                conx.Open();

            }
            catch(Exception erro) {

                msg = "Ocorreu um erro na conexão com o banco " + erro.Message;

            }

            return conx;

        }

        //desconectando
        public MySqlConnection MyCloseBd(){

            try {

                conx.Close();

            }
            catch (Exception erro) {

                msg = "Ocorreu um erro ao fechar o banco " + erro.Message;

            }

            return conx;

        }

    }
}