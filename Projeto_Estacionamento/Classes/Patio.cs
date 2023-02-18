using System.Reflection.PortableExecutable;

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

        #region "Métodos auxiliares"
        public void FaturamentoTotal()
        {
            Console.WriteLine($"Faturamento total: {Faturamento:c}");
        }

        #endregion

        //(CREATE) Esse método vai adicionar o veículo na classe.
        public void AdicionarEntradaVeiculoLINQ(Veiculo veiculo)
        {
            //Com o método do LINQ, podemos procurar um veículo específico. Nesse caso estou verificando se já não existe o veículo, que o usuário quer inserir.
            var novoVeiculo = Veiculos.Where(Placa => Placa.Placa == veiculo.Placa).FirstOrDefault();
            if (novoVeiculo == null)
            {
                //Adicionando a hora
                veiculo.HoraEntrada = DateTime.Now;
                Veiculos.Add(veiculo);
            }
            else
            {
                throw new Exception("Esse veículo já é existente, pois não foi cadastro sua saída.");
            }
        }

        //(DELETE) Cadastra a saída de um veículo. Passando como parametro a placa, para procurarmos o veículo.
        public void SaidaDeVeiculoLINQ(string placaveiculo)
        {
            var veiculoAchado = Veiculos.Where(veiculo => veiculo.Placa == placaveiculo).FirstOrDefault();
            //Caso o veículo exista.
            if (veiculoAchado != null)
            {
                //Método de imprimir os dados de um veículo
                Console.WriteLine(veiculoAchado.ToString());
                Console.WriteLine("Deseja realmente registrar a saída do veículo acima? [1] SIM / [2] CANCELAR");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        //Registra a saída do veículo.
                        veiculoAchado.HoraSaida = DateTime.Now;
                        double valorCobrado = 0;
                        //Operação que vai ter o total de tempo do usuário.
                        var tempoPermanecido = veiculoAchado.HoraSaida - veiculoAchado.HoraEntrada;
                        if (veiculoAchado.TipoVeiculo == TipoVeiculo.Carro)
                        {
                            //Calculo da cobrança. Estou pegando o tempo em minutos.
                            //O Math.Ceiling vai arrendondar o número. Ex:. temos o número 1,799 = 2,0
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 15 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 60)
                            {
                                valorCobrado = 23.00;
                            }
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 60 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 120)
                            {
                                valorCobrado = 26.00;
                            }
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 120 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 300)
                            {
                                valorCobrado = 40.00;
                            }
                        }
                        else if (veiculoAchado.TipoVeiculo == TipoVeiculo.Moto)
                        {
                            //Calculo da cobrança.
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 15 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 60)
                            {
                                valorCobrado = 12.00;
                            }
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 60 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 120)
                            {
                                valorCobrado = 15.00;
                            }
                            if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 120 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 300)
                            {
                                valorCobrado = 26.00;
                            }
                        }
                        //Mostrando para o usuário quanto será cobrado.
                        Console.WriteLine($"Valor total cobrado {valorCobrado:c}");
                        Faturamento += valorCobrado;
                        //Removendo o veículo da lista(Veiculos).
                        Veiculos.Remove(veiculoAchado);
                        Console.WriteLine("Veículo removido com sucesso!");
                        
                        break;
                    case 2:
                        Console.WriteLine("Operação concelada com sucesso!");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Veículo não encontrado...");
            }
        }

        //(READ) método que vai procurar o carro. Tem o paramatro que o usuário vai digitar.
        public Veiculo EncontrarVeiculoLINQ(string placaUsuario)
        {
            //Com o LINQ fazemos a mesma coisa, só que com menos linhas de código. 
            var veiculoAchado = Veiculos.Where(placa => placa.Placa == placaUsuario).FirstOrDefault();
            return veiculoAchado;
        }


        //(READ) Método que vai mostrar apenas os carros.
        public void ImprimirCarros()
        {
            Console.WriteLine("=-=-=-=-=-= MOTOS ESTACINADOS =-=-=-=-=-=\n");

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
            foreach (var item in _veiculos)
            {
                //Vai verificar se o tipo do veículo é um carro.
                if (item.TipoVeiculo == TipoVeiculo.Carro)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        //(READ) Vai imprimir apenas as motos.
        public void ImprimirMotos()
        {
            Console.WriteLine("=-=-=-=-=-= MOTOS ESTACINADOS =-=-=-=-=-=\n");

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            foreach (var item in _veiculos)
            {
                //Vai verificar se o tipo do veículo é um carro.
                if (item.TipoVeiculo == TipoVeiculo.Moto)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        //(UPDATE) Alteração de veículo
        public Veiculo UpdateVeiculo(string placa, string proprietario, string modelo, string cor, string placaAlterada)
        {
            Veiculo veiculoEncontrado = Veiculos.Where(vei => vei.Placa == placa).FirstOrDefault();
            var veiculoSub = veiculoEncontrado;
            if (veiculoSub != null)
            {
                Veiculos.Remove(veiculoEncontrado);
                veiculoSub.AlterarVeiculo(proprietario, modelo, cor, placaAlterada);
                Veiculos.Add(veiculoSub);
                return veiculoSub;
            }
            else
            {
                return veiculoSub;
            }
        }
        #endregion
    }
}