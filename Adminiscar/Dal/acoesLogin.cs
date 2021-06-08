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

            MySqlCommand cmd = new MySqlCommand("SELECT NOME_FUNC, SENHA, NIVEL_ACESSO FROM FUNCIONARIO INNER JOIN LOGIN_SYS ON COD_FUNC_FK = 1 AND SENHA = 123456789", con.MyConectorBd());
 
            //quando for pegar dados do usuario
            /*cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = user.senha;*/

            MySqlDataReader leitor; //preparando o comando sql

            leitor = cmd.ExecuteReader();   //executando o comando sql

            //fazendo uma codição
            if (leitor.HasRows)
            {

                while (leitor.Read())
                {

                    usuario.user = Convert.ToString(leitor["NOME_FUNC"]);
                    usuario.pass = Convert.ToString(leitor["SENHA"]);
                    usuario.tipoUser = Convert.ToString(leitor["NIVEL_ACESSO"]);

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