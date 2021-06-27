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

        //locacao para alugar
        public List<string> listLoc(string clienteLoc, string cnpjLoc, string cpfLoc, string cnhLoc, string cellLoc, string tellLoc, string Veiculos, string som, string somBt, string gps, string dateLoc) {
            
            //variavel Local
            List<string> listaLocacao = new List<string>();

            //parte do codigo para guardar na lista
            if (clienteLoc == null || cpfLoc == null || cnhLoc == null)
            {   //verificando esta vazio

                //enviando um codigo para dizer que não tem nada
                listaLocacao.Add("0");

            }

            //verificando se o cnpj veio com algo
            if (cnpjLoc != null)
            {
                //adicionando a lista
                listaLocacao.Add(clienteLoc);
                listaLocacao.Add(cnpjLoc);
                listaLocacao.Add(cpfLoc);
                listaLocacao.Add(cnhLoc);

            }
            else {

                //adicionando a lista
                listaLocacao.Add(clienteLoc);
                listaLocacao.Add("Não tem");
                listaLocacao.Add(cpfLoc);
                listaLocacao.Add(cnhLoc);

            }

            //verificando se tem um telefone ou celular
            if (cellLoc == null || tellLoc != null)
            {

                listaLocacao.Add("Não tem celular");
                listaLocacao.Add(tellLoc);

            }

            if (cellLoc != null || tellLoc == null)
            {

                listaLocacao.Add(cellLoc);
                listaLocacao.Add("Não tem Telefone");

            }
            else {

                listaLocacao.Add(cellLoc);
                listaLocacao.Add(tellLoc);

            }



            return listaLocacao;

        }
    }
}