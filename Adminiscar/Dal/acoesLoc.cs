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
     * Methods da classe Locação
     * 
     * */
    public class acoesLoc
    {
        
        Conexao conect = new Conexao(); //istanciando o meu objeto classe conect

        //dropList Veiculos
        public List<string> listVeiculoLoc() {

            //variaveis Locais
            List<string> listaVeiculo = new List<string>();

            //Select os veiculos comando sql
            MySqlCommand cmd = new MySqlCommand("SELECT NOME_CAR FROM carro", conect.MyConectorBd());

            MySqlDataReader leitor; //preparando a variavel para receber o select

            leitor = cmd.ExecuteReader();   //executando no banco

            while (leitor.Read()) {

                listaVeiculo.Add(leitor.GetString("NOME_CAR"));
                
            }

            conect.MyCloseBd();

            return listaVeiculo;

        }
        
        //drop codVeiculo
        public List<string> listCodVecLoc() {

            //variavel Local
            List<string> listaCodVec = new List<string>();

            //Select os veiculos comando sql
            MySqlCommand cmd = new MySqlCommand("SELECT COD_CAR FROM carro", conect.MyConectorBd());

            MySqlDataReader leitor; //preparando a variavel para receber o select

            leitor = cmd.ExecuteReader();   //executando no banco

            while (leitor.Read()){

                listaCodVec.Add(leitor.GetString("COD_CAR"));

            }

            conect.MyCloseBd();

            return listaCodVec;

        }


    }
}