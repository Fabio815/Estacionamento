using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estacionamento.Classes
{
    public class Veiculo
    {
        private string _placa { get; set; }

        private string _proprietario { get; set; }

        private TipoVeiculo _tipoVeiculo { get; set; }

        public TipoVeiculo TipoVeiculo
        {
            get
            {
                return _tipoVeiculo;
            }
            set
            {
                _tipoVeiculo = value;
            }
        }

        public string Placa
        {
            get
            {
                return _placa;
            }
            set
            {
                //Colocando condição ao inserir a placa.
                if (value[3] != '-')
                {
                    throw new ArgumentException("O 4° digito deve ser -");
                }
                if (value.Length != 8)
                {
                    throw new ArgumentException("A placa deve conter 7 dígitos");
                }
                else
                {
                    _placa = value;
                }
            }
        }
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Proprietario
        {
            get
            {
                return _proprietario;
            }
            set
            {
                _proprietario = value;
            }
        }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSaida { get; set; }

        //Método que vai alterar o veículo.
        public void AlterarVeiculo(string proprietario, string modelo, string cor, string placaAlterada)
        {
            this.Proprietario = proprietario;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Placa = placaAlterada;
        }

        public override string ToString()
        {
            return $"\nDados do veículo: \n" +
                    $"Proprietario: {this.Proprietario}\n" +
                    $"Placa: {this.Placa}\n" +
                    $"Modelo {this.Modelo}\n" +
                    $"Cor: {this.Cor} \n" +
                    $"Tipo do Veículo: {this.TipoVeiculo.ToString()}\n" +
                    $"Hora de Entrada: {this.HoraEntrada}\n";
        }
    }
}
