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
    public class acoesCar
    {
        Conexao conect = new Conexao(); //criando a conexao

        //cadastro
        public void cadastroCar(Carro carro) {

            //cadastro do veiculo
            MySqlCommand cmd = new MySqlCommand("INSERT INTO Carro(NOME_CAR, PLACA, RENAVAM, MODELO, CATEGORIA, COMBUTIVEL, QUILOMETRAGEM, SITUACAO, VALOR_SEMANAL, VALOR_MENSAL, SOM, SOM_BT)VALUES(@nomecar, @placa, @renavam, @modelo, @cart, @comb, @khm, 'normal', @vls, @vlm, 'n', 'n')", conect.MyConectorBd());
            cmd.Parameters.Add("@nomecar", MySqlDbType.VarChar).Value = carro.nomeCar;
            cmd.Parameters.Add("@placa", MySqlDbType.VarChar).Value = carro.placaCar;
            cmd.Parameters.Add("@renavam", MySqlDbType.VarChar).Value = carro.renavCar;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = carro.modeloCar;
            cmd.Parameters.Add("@cart", MySqlDbType.VarChar).Value = carro.categoriaCar;
            cmd.Parameters.Add("@comb", MySqlDbType.VarChar).Value = carro.combCar;
            cmd.Parameters.Add("@khm", MySqlDbType.VarChar).Value = carro.KmhCar;
            //cmd.Parameters.Add("@sts", MySqlDbType.VarChar).Value = carro.statusCar;
            cmd.Parameters.Add("@vls", MySqlDbType.VarChar).Value = Convert.ToDouble(carro.vlsmanlCar);
            cmd.Parameters.Add("@vlm", MySqlDbType.VarChar).Value = Convert.ToDouble(carro.vlmensCar);

            //executando a insert
            cmd.ExecuteNonQuery();


            //fechando a conexao
            conect.MyCloseBd();
        }

        //consulta
        public static List<Carro> consultaCar()
        {

            //variaveis locais
            List<Carro> listaCarro = new List<Carro>();


            //Cliente cli = new Cliente();
            Conexao con = new Conexao();

            //comando sql
            MySqlCommand cmdSlct = new MySqlCommand("select COD_CAR, NOME_CAR, RENAVAM, PLACA, MODELO from carro", con.MyConectorBd());

            MySqlDataReader leitor; //preparando o select

            leitor = cmdSlct.ExecuteReader();   //executando no banco

            //verificando se vem algo

            //passando por todos as busca e colocando no list<objeto>
            while (leitor.Read())
            {

                listaCarro.Add(new Carro
                {
                    codCar = leitor.GetString("COD_CAR"),
                    nomeCar = leitor.GetString("NOME_CAR"),
                    renavCar = leitor.GetString("RENAVAM"),
                    placaCar = leitor.GetString("PLACA"),
                    modeloCar = leitor.GetString("MODELO")
                });

            }

            con.MyCloseBd();

            return listaCarro;

        }

        //detalhe carro
        public List<string> detalheCar(string cod) {

            //variavel local
            int codCar;
            List<string> listaCarro = new List<string>();
            codCar = Convert.ToInt32(cod);  //o codigo do carro

            //comando sql
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM carro WHERE COD_CAR = " + codCar,conect.MyConectorBd());

            //preparando select
            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            while (leitor.Read()) {

                listaCarro.Add(leitor.GetString("COD_CAR"));
                listaCarro.Add(leitor.GetString("NOME_CAR"));
                listaCarro.Add(leitor.GetString("PLACA"));
                listaCarro.Add(leitor.GetString("RENAVAM"));
                listaCarro.Add(leitor.GetString("MODELO"));
                listaCarro.Add(leitor.GetString("CATEGORIA"));
                listaCarro.Add(leitor.GetString("COMBUTIVEL"));
                listaCarro.Add(leitor.GetString("SITUACAO"));
                listaCarro.Add(leitor.GetString("VALOR_SEMANAL"));
                listaCarro.Add(leitor.GetString("VALOR_MENSAL"));
                listaCarro.Add(leitor.GetString("SOM"));
                listaCarro.Add(leitor.GetString("SOM_BT"));

            }

            conect.MyCloseBd();

            return listaCarro;

        }

        //editar carro
        public void updateCar(Carro car, string cod) {

            //variavel local
            int codCar;
            codCar = Convert.ToInt32(cod);

            //comando sql
            //comando sql alterando o cliente
            MySqlCommand cmd = new MySqlCommand("UPDATE carro SET NOME_CAR=@nomecarro, PLACA=@placa, RENAVAM=@renavam, MODELO=@modelo, CATEGORIA=@cat, COMBUTIVEL=@com, QUILOMETRAGEM=@khm, SITUACAO=@sts, VALOR_SEMANAL=@vls, VALOR_MENSAL=@vlm, SOM=@som, SOM_BT=@sbt, GPS=@gps WHERE COD_CAR = " + codCar, conect.MyConectorBd());

            //add parametro para o update
            cmd.Parameters.Add("@nomecarro", MySqlDbType.VarChar).Value = car.nomeCar;
            cmd.Parameters.Add("@placa", MySqlDbType.VarChar).Value = car.placaCar;
            cmd.Parameters.Add("@renavam", MySqlDbType.VarChar).Value = car.renavCar;
            cmd.Parameters.Add("@modelo", MySqlDbType.VarChar).Value = car.modeloCar;
            cmd.Parameters.Add("@cat", MySqlDbType.VarChar).Value = car.categoriaCar;
            cmd.Parameters.Add("@com", MySqlDbType.VarChar).Value = car.combCar;
            cmd.Parameters.Add("@khm", MySqlDbType.Int32).Value = car.KmhCar;
            cmd.Parameters.Add("@sts", MySqlDbType.VarChar).Value = car.statusCar;
            cmd.Parameters.Add("@vls", MySqlDbType.Double).Value = car.vlsmanlCar;
            cmd.Parameters.Add("@vlm", MySqlDbType.Double).Value = car.vlsmanlCar;
            cmd.Parameters.Add("@som", MySqlDbType.VarChar).Value = car.somCar;
            cmd.Parameters.Add("@sbt", MySqlDbType.VarChar).Value = car.somBwCar;
            cmd.Parameters.Add("@gps", MySqlDbType.VarChar).Value = car.gpsCar;

            cmd.ExecuteNonQuery();

        }

        //deletar carro
        public void deletarCar(string cod) {

            //variavel local
            int codCar;

            codCar = Convert.ToInt32(cod);

            //comando sql
            MySqlCommand cmd = new MySqlCommand("DELETE FROM carro WHERE COD_CAR =" + cod, conect.MyConectorBd());

            //executando
            cmd.ExecuteNonQuery();

            //close conexao
            conect.MyCloseBd();

        }

    }
}