using Projeto_Estacionamento.Classes;

namespace Projeto.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void LocalizaVeiculos()
        {
            //Arrenge
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = "Pedro";
            veiculo.Placa = "DJE-2OJ9";
            veiculo.Modelo = "Vecta";
            veiculo.Cor = "Vermelho";
            estacionamento.AdicionarEntradaVeiculoLINQ(veiculo);

            //Act
            var veiculoEncontrado = estacionamento.EncontrarVeiculoLINQ(veiculo.Placa);

            //Assert
            Assert.Equal(veiculo.Placa, veiculoEncontrado.Placa);
        }
    }
}