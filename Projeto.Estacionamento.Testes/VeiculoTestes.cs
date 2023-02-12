using Projeto_Estacionamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void DadosVeiculos()
        {
            //Arrenge
            Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = "Roberto";
            veiculo.Placa = "JEJ-9K9J";
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Opala";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Dados do veículo: ", dados);
        }
    }
}
