using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Adminiscar.Models;

namespace Adminiscar.Dal
{
    public class FuncServices
    {
        public static List<ObjetoFuncTest> GetFuncionarios()
        {
            var listaFuncionarios = new List<ObjetoFuncTest>()
            {
                new ObjetoFuncTest { FuncionarioId=1, Nome="Macoratti", Email="macoratti@yahoo.com", Nascimento= DateTime.Now.AddYears(-45), Salario=5000.00M, Sexo="Masculino", Setor="TI"},
                new ObjetoFuncTest { FuncionarioId=2, Nome="Pedro", Email="pedro@yahoo.com", Nascimento= DateTime.Now.AddYears(-25), Salario=4000.00M, Sexo="Masculino", Setor="Engenharia"},
                new ObjetoFuncTest { FuncionarioId=3, Nome="Jefferson", Email="jeff@yahoo.com", Nascimento= DateTime.Now.AddYears(-20), Salario=3500.00M, Sexo="Masculino", Setor="Engenharia"},
                new ObjetoFuncTest { FuncionarioId=4, Nome="Miriam", Email="miriam@yahoo.com", Nascimento= DateTime.Now.AddYears(-40), Salario=3000.00M, Sexo="Feminino", Setor="Contabilidade"},
                new ObjetoFuncTest { FuncionarioId=5, Nome="Bianca", Email="bibi@yahoo.com", Nascimento= DateTime.Now.AddYears(-22), Salario=6000.00M, Sexo="Feminino", Setor="Contabilidade"},
                new ObjetoFuncTest { FuncionarioId=6, Nome="Janice", Email="janjan@yahoo.com", Nascimento= DateTime.Now.AddYears(-23), Salario=4000.00M, Sexo="Feminino", Setor="RH"},
                new ObjetoFuncTest { FuncionarioId=7, Nome="Jessica", Email="jesslang@yahoo.com", Nascimento= DateTime.Now.AddYears(-26), Salario=4500.00M, Sexo="Feminino", Setor="RH"},
                new ObjetoFuncTest { FuncionarioId=8, Nome="Marcia", Email="marcia@yahoo.com", Nascimento= DateTime.Now.AddYears(-35), Salario=5000.00M, Sexo="Feminino", Setor="RH"},
                new ObjetoFuncTest { FuncionarioId=9, Nome="Mario", Email="mario@yahoo.com", Nascimento= DateTime.Now.AddYears(-48), Salario=4000.00M, Sexo="Masculino", Setor="Engenharia"},
                new ObjetoFuncTest { FuncionarioId=10, Nome="Carlos", Email="carlos@yahoo.com", Nascimento= DateTime.Now.AddYears(-32), Salario=3000.00M, Sexo="Masculino", Setor="Administrativo"},
                new ObjetoFuncTest { FuncionarioId=11, Nome="Adriano", Email="adriano@yahoo.com", Nascimento= DateTime.Now.AddYears(-28), Salario=3500.00M, Sexo="Masculino", Setor="Administrativo"},
                new ObjetoFuncTest { FuncionarioId=12, Nome="Igor", Email="igor@yahoo.com", Nascimento= DateTime.Now.AddYears(-20), Salario=2500.00M, Sexo="Masculino", Setor="Administrativo"}
            };
            return listaFuncionarios;
        }
    }
}