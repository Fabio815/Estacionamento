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

        public void AlterarVeiculo(string proprietario, string modelo, string cor, string placaAlterada)
        {
            this.Proprietario = proprietario;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Placa = placaAlterada;
        }
    }
}
