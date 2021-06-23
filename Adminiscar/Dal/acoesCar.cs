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

    }
}