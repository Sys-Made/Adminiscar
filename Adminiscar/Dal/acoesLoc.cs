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

        //pre locacao
        public List<string> listLoc(string clienteLoc, string cnpjLoc, string cpfLoc, string cnhLoc, string cellLoc, string tellLoc, string Veiculos, string som, string somBt, string gps, string dateLoc) {
            
            //variavel Local
            List<string> listaLocacao = new List<string>();
            string nomeVeiculo = "";
            string dias = "";
            string vlCompra;
            double valorBs = 0;
            double valorSm = 0;
            double valorMs = 0;
            int cod_car;
            double valorCompra;

            //parte do codigo para guardar na lista
            if (clienteLoc == null || cpfLoc == null || cnhLoc == null)
            {   //verificando esta vazio

                //enviando um codigo para dizer que não tem nada
                listaLocacao.Add("0");

            }

            //verificando se o cnpj veio com algo
            if (cnpjLoc != null || cnpjLoc != "")
            {
                //adicionando a lista
                listaLocacao.Add(clienteLoc);
                listaLocacao.Add(cpfLoc);
                listaLocacao.Add(cnpjLoc);
                listaLocacao.Add(cnhLoc);

            }
            else {

                //adicionando a lista
                listaLocacao.Add(clienteLoc);
                listaLocacao.Add(cpfLoc);
                listaLocacao.Add("Não tem");
                listaLocacao.Add(cnhLoc);

            }

            //add o veiculo na lista
            cod_car = Convert.ToInt32(Veiculos);

            MySqlCommand cmd = new MySqlCommand("SELECT COD_CAR, NOME_CAR, VALOR_DIARIO, VALOR_SEMANAL, VALOR_MENSAL FROM CARRO WHERE COD_CAR =" + cod_car, conect.MyConectorBd());  //comando sql para trazer o carro

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();

            while (leitor.Read()) {

                nomeVeiculo = leitor.GetString("NOME_CAR");
                valorBs = leitor.GetDouble("VALOR_DIARIO");
                valorSm = leitor.GetDouble("VALOR_SEMANAL");
                valorMs = leitor.GetDouble("VALOR_MENSAL");

            }

            listaLocacao.Add(nomeVeiculo);

            //verificando se vai ter som ou não
            if (som == "" && somBt == "")
            {

                listaLocacao.Add("Não tem som");

            }
            else if (som != null)
            {

                listaLocacao.Add(som);

            }
            else {

                listaLocacao.Add(somBt);

            }

            //verificando se tem um telefone ou celular
            if (cellLoc == "" && tellLoc != "")
            {

                listaLocacao.Add("Não tem celular");
                listaLocacao.Add(tellLoc);

            }

            if (cellLoc != "" && tellLoc == "")
            {

                listaLocacao.Add(cellLoc);
                listaLocacao.Add("Não tem Telefone");

            }
            else {

                listaLocacao.Add(cellLoc);
                listaLocacao.Add(tellLoc);

            }

            
            //Data da entrega
            if (dateLoc == null)
            {

                listaLocacao.Add("Data não informada ou não encontrada");

            }
            else {

                listaLocacao.Add(dateLoc);

            }

            string vlBase = Convert.ToString(valorBs);  //convertendo, pois esqueci da lista string
            listaLocacao.Add(vlBase);

            /*fazendo a conta(testando o DateTime)*/ 
            DateTime dtNow = DateTime.Today;    //pegando a data de agora
            DateTime dtEntg = Convert.ToDateTime(dateLoc);  //convertendo a string em data

            TimeSpan date = dtEntg - dtNow; //retornar um intervalo de espaço

            int totalDias = date.Days;

            //verificando se for hoje
            if (totalDias == 0)
            {

                dias = "Entregar Hoje";
                listaLocacao.Add(dias);

            }
            else {

                dias = "Entregar daqui a " + Convert.ToString(totalDias) + " dias";
                listaLocacao.Add(dias);

            }

            //fazendo o total da compra
            if (totalDias <= 6) {

                valorCompra = valorBs * totalDias;  //fazendo a conta

                if (valorCompra == 0) {

                    valorCompra = valorBs;

                }

                vlCompra = Convert.ToString(valorCompra);   //convertendo em string

                listaLocacao.Add(vlCompra);

            } else if (totalDias == 7) {

                valorCompra = valorSm;
                vlCompra = Convert.ToString(valorCompra);   //convertendo em string

                listaLocacao.Add(vlCompra);

            } else if (totalDias >= 29) {

                valorCompra = valorMs;
                vlCompra = Convert.ToString(valorCompra);

                listaLocacao.Add(vlCompra);

            }

            //codigo do carro
            listaLocacao.Add(Veiculos);

            return listaLocacao;

        }

        //alugando
        public void finPedidoLoc(string nomecli, string cpfcli, string cnpjcli, string cnhcli, string codcar, string tellcli, string cellcli, string dateEnt, string valorTotal) {

            //verificando se o cliente já tem cadastro
            MySqlCommand cmd = new MySqlCommand("SELECT NOME_CLIENTE, CPF_CNPJ FROM cliente WHERE CPF_CNPJ = '" + cpfcli + "'", conect.MyConectorBd());

            //preparando slct 
            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //verificando se existe cliente
            if (!leitor.HasRows) {

                //fechando primeiro a conexao
                conect.MyCloseBd();

                Cliente cliente = new Cliente();    //chamando o objeto cliente
                acoesCli acsCli = new acoesCli();   //chamando o method cliente

                //fazendo objeto cliente
                cliente.nomeCli = nomecli;
                cliente.cpfCli = cpfcli;
                cliente.cnpjCli = cnpjcli;
                cliente.cnhCli = cnhcli;
                cliente.tellCli = tellcli;
                cliente.tell2Cli = cellcli;

                acsCli.cadastroCli(cliente);

            }



        }
    }
}