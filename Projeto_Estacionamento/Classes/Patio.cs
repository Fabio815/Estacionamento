namespace Projeto_Estacionamento.Classes
{
    public class Patio
    {
        private List<Veiculo> _veiculos { get; set; }
        private double _faturamento { get; set; }

        public double Faturamento
        {
            get
            {
                return _faturamento;
            }
            set
            {
                _faturamento = value;
            }
        }

        public List<Veiculo> Veiculos
        {
            get
            {
                return _veiculos;
            }
            set
            {
                this._veiculos = value;
            }
        }

        public Patio()
        {
            Veiculos = new List<Veiculo>();
            Faturamento = 0;
        }


        #region "Métodos do CRUD"
        //Esse método vai adicionar o veículo na classe.
        public void AdicionarEntradaVeiculo(Veiculo veiculo)
        {
            //Variável que vai receber os dados do veículo, caso ele exista.
            Veiculo existente = null;
            //Vamos ver se já não existe o veiculo. Para isso vamos percorrer a Lista de veículos com foreach.
            foreach (var item in _veiculos)
            {
                if (item.Placa.Equals(veiculo.Placa))
                {
                    existente = item;
                }
            }
            //Ai no caso ele exista, vamos gerar uma excessão que vai mandar uma mensagem
            if (existente != null)
            {
                throw new Exception("Esse veículo já é existente, pois não foi cadastro sua saída.");
            }
            else
            {
                //Passa a hora que e adiciono o veículo
                veiculo.HoraEntrada = DateTime.Now;
                Veiculos.Add(veiculo);
            }
        }

        public void SaidaDeVeiculo(string placaVeiculo)
        {
            //Essa variável vai armazenar o veículo.
            Veiculo veiculoAchado = null;
            foreach (var item in _veiculos)
            {
                //Caso o veículo exista.
                if (item.Placa.Equals(placaVeiculo))
                {
                    
                    veiculoAchado = item;
                    //Vamos imprimir o veículo encontrado, para o usuário confirmar se é ele mesmo que vamos retirar.
                    Console.WriteLine(ImprimirVeieculo(veiculoAchado));

                    Console.WriteLine("Deseja realmente registrar a saída do veículo? [1]Sim / [2]Cancelar");
                    int opcao = Convert.ToInt32(Console.ReadLine());
                    if (opcao == 1)
                    {                       
                        item.HoraSaida = DateTime.Now;
                        //Quanto tempo que ficou no estacionamento
                        var tempoPermanecido = item.HoraSaida - item.HoraEntrada;
                        double valorCobrado = 0;
                        if (item.TipoVeiculo == TipoVeiculo.Carro)
                        {
                            //Calculo da cobrança.
                            valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 2.21;
                        }
                        if (item.TipoVeiculo == TipoVeiculo.Moto)
                        {
                            valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 1.24;
                        }

                        Console.WriteLine($"Valor total cobrado: {valorCobrado:c}");
                        //Adicionando ao caixa.
                        Faturamento += valorCobrado;
                        //E por ultimo vamos remover esse item da lista de carros.
                        _veiculos.Remove(item);
                        Console.WriteLine("Veículo REMOVIDO com sucesso!");
                        break;
                    }
                    else
                    {
                        throw new Exception("Operação CANCELADA com sucesso!");
                    }
                }
            }
            if (!(veiculoAchado != null))
            {
                throw new Exception("Veículo não foi encontrado...");
            }
        }

        public void FaturamentoTotal()
        {
            Console.WriteLine($"Faturamento total: {Faturamento:c}");
        }

        public Veiculo EncontrarVeiculo(string placa)
        {
            Veiculo veiculoAchado = null;
            foreach (var item in _veiculos)
            {
                if (item.Placa.Equals(placa))
                {
                    veiculoAchado = item;
                }
            }

            if (veiculoAchado == null)
            {
                throw new Exception("Veículo não encontrado... Tente outro");
            }
            return veiculoAchado;
        }

        public string ImprimirVeieculo(Veiculo veiculo)
        {
            string imprimir = $"\nProprietário: {veiculo.Proprietario}\n" +
            $"Placa: {veiculo.Placa}\n" +
            $"Modelo: {veiculo.Modelo} \n" +
            $"Cor: {veiculo.Cor} \n" +
            $"Hora de Entrada: {veiculo.HoraEntrada}";
            return imprimir;
        }

        public void ImprimirCarros()
        {
            string imprimir = "";
            foreach (var item in _veiculos)
            {
                if (item.TipoVeiculo == TipoVeiculo.Carro)
                {
                    imprimir = $"\nProprietário: {item.Proprietario}\n" +
                    $"Placa: {item.Placa}\n" +
                    $"Modelo: {item.Modelo} \n" +
                    $"Cor: {item.Cor} \n" +
                    $"Hora de Entrada: {item.HoraEntrada}";
                    Console.WriteLine(imprimir);
                }
            }
            if (imprimir == "")
            {
                throw new ArgumentException("Não tem veículos cadastrados");
            }
        }

        public void ImprimirMotos()
        {
            string imprimir = "";
            foreach (var item in _veiculos)
            {
                if (item.TipoVeiculo == TipoVeiculo.Moto)
                {
                    imprimir = $"\nProprietário: {item.Proprietario}\n" +
                    $"Placa: {item.Placa}\n" +
                    $"Modelo: {item.Modelo} \n" +
                    $"Cor: {item.Cor} \n" +
                    $"Hora de Entrada: {item.HoraEntrada}";
                    Console.WriteLine(imprimir);
                }
            }
            if (imprimir == "")
            {
                throw new ArgumentException("Não tem veículos cadastrados");
            }
        }

        #endregion
    }
}