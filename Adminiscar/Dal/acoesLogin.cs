using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Adminiscar.Models;

namespace Adminiscar.Dal
{
    public class acoesLogin
    {
        //criando uma nova conexao
        Conexao con = new Conexao();

        //criando a funcao que vai ser o usuario existe
        public void LogarUsuario(LoginACS usuario) {

            MySqlCommand cmd = new MySqlCommand("SELECT NOME_FUNC, NIVEL_ACESSO FROM FUNCIONARIO INNER JOIN LOGIN_SYS ON COD_FUNC_FK = COD_FUNC WHERE EMAIL = @usuario  AND SENHA = @Senha", con.MyConectorBd());
 
            //quando for pegar dados do usuario
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = usuario.user;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = usuario.pass;

            MySqlDataReader leitor; //preparando o comando sql

            leitor = cmd.ExecuteReader();   //executando o comando sql

            //fazendo uma codição
            if (leitor.HasRows)
            {

                while (leitor.Read())
                {

                    usuario.user = leitor.GetString("NOME_FUNC");
                    //usuario.pass = leitor.GetString("SENHA");
                    usuario.tipoUser = leitor.GetString("NIVEL_ACESSO");

                }

            }
            else {

                usuario.user = null;
                usuario.pass = null;
                usuario.tipoUser = null;

            }

            con.MyCloseBd();    //fechando a conexao

        }

    }
}