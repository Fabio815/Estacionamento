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

        [Theory]
        [InlineData("Cardozo", "Civic", "Prata", "DHF-3J4I")]
        [InlineData("Fábio", "Astra", "Branco", "FHN-I9B7")]
        public void LocalizaVariosVeiculos(string proprietario, string modelo, string cor, string placa)
        {
            //Arrenge
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Modelo = modelo;
            veiculo.Cor = cor;
            veiculo.Placa = placa;
            estacionamento.AdicionarEntradaVeiculoLINQ(veiculo);
            
            //Act
            var veiculosEncontrado = estacionamento.EncontrarVeiculoLINQ(placa);

            //Assert
            Assert.Equal(placa, veiculosEncontrado.Placa);
        }
    }
}