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

        public string ImprimirVeieculo(Veiculo veiculo)
        {
            string imprimir = $"\nProprietário: {veiculo.Proprietario}\n" +
            $"Placa: {veiculo.Placa}\n" +
            $"Modelo: {veiculo.Modelo} \n" +
            $"Cor: {veiculo.Cor} \n" +
            $"Hora de Entrada: {veiculo.HoraEntrada}";
            return imprimir;
        }

        public void FaturamentoTotal()
        {
            Console.WriteLine($"Faturamento total: {Faturamento:c}");
        }

        #endregion
        #region "Métodos antigos"
        //public void AdicionarEntradaVeiculo(Veiculo veiculo)
        //{
        //    //Variável que vai receber os dados do veículo, caso ele exista.
        //    Veiculo existente = null;
        //    //Vamos ver se já não existe o veiculo. Para isso vamos percorrer a Lista de veículos com foreach.
        //    foreach (var item in _veiculos)
        //    {
        //        if (item.Placa.Equals(veiculo.Placa))
        //        {
        //            existente = item;
        //        }
        //    }
        //    //Ai no caso ele exista, vamos gerar uma excessão que vai mandar uma mensagem
        //    if (existente != null)
        //    {
        //        throw new Exception("Esse veículo já é existente, pois não foi cadastro sua saída.");
        //    }
        //    else
        //    {
        //        //Passa a hora que e adiciono o veículo
        //        veiculo.HoraEntrada = DateTime.Now;
        //        Veiculos.Add(veiculo);
        //    }
        //}

        //public Veiculo EncontrarVeiculo(string placa)
        //{
        //    //Vou criar uma variável do tipo Veiculo, para armazenar os dados, caso o carro exista.
        //    Veiculo veiculoAchado = null;
        //    //Com o foreach vamos percorrer a lista de veiculos
        //    foreach (var item in _veiculos)
        //    {
        //        if (item.Placa.Equals(placa))
        //        {
        //            //caso a placa exista a variável veiculoAchado vai receber os dados desse veículo
        //            veiculoAchado = item;
        //        }
        //    }

        //    if (veiculoAchado == null)
        //    {
        //        throw new Exception("Veículo não encontrado... Tente outro");
        //    }
        //    // Vamos retornar o veiculo achado.
        //    return veiculoAchado;
        //}


        //public void SaidaDeVeiculo(string placaVeiculo)
        //{
        //    //Essa variável vai armazenar o veículo.
        //    Veiculo veiculoAchado = null;
        //    foreach (var item in Veiculos)
        //    {
        //        //Caso o veículo exista.
        //        if (item.Placa.Equals(placaVeiculo))
        //        {

        //            veiculoAchado = item;
        //            //Vamos imprimir o veículo encontrado, para o usuário confirmar se é ele mesmo que vamos retirar.
        //            Console.WriteLine(ImprimirVeieculo(veiculoAchado));

        //            Console.WriteLine("Deseja realmente registrar a saída do veículo? [1]Sim / [2]Cancelar");
        //            int opcao = Convert.ToInt32(Console.ReadLine());
        //            if (opcao == 1)
        //            {
        //                item.HoraSaida = DateTime.Now;
        //                //Quanto tempo que ficou no estacionamento
        //                var tempoPermanecido = item.HoraSaida - item.HoraEntrada;
        //                double valorCobrado = 0;
        //                if (item.TipoVeiculo == TipoVeiculo.Carro)
        //                {
        //                    //Calculo da cobrança.
        //                    //O Math.Ceiling vai arrendondar o número. Ex:. temos o número 1,799 = 2,0
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 15 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 60)
        //                    {
        //                        valorCobrado = 23.00;
        //                    }
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 60 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 120)
        //                    {
        //                        valorCobrado = 26.00;
        //                    }
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 120 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 300)
        //                    {
        //                        valorCobrado = 40.00;
        //                    }
        //                    //valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 2.21;
        //                }
        //                if (item.TipoVeiculo == TipoVeiculo.Moto)
        //                {
        //                    //Calculo da cobrança.
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 15 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 60)
        //                    {
        //                        valorCobrado = 12.00;
        //                    }
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 60 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 120)
        //                    {
        //                        valorCobrado = 15.00;
        //                    }
        //                    if (Math.Ceiling(tempoPermanecido.TotalMinutes) > 120 && Math.Ceiling(tempoPermanecido.TotalMinutes) <= 300)
        //                    {
        //                        valorCobrado = 26.00;
        //                    }
        //                    //valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 1.24;
        //                }

        //                Console.WriteLine($"Valor total cobrado: {valorCobrado:c}");
        //                //Adicionando ao caixa.
        //                Faturamento += valorCobrado;
        //                //E por último vamos remover esse item da lista de carros.
        //                _veiculos.Remove(item);
        //                Console.WriteLine("Veículo REMOVIDO com sucesso!");
        //                break;
        //            }
        //            else
        //            {
        //                throw new Exception("Operação CANCELADA com sucesso!");
        //            }
        //        }
        //    }
        //    if (!(veiculoAchado != null))
        //    {
        //        throw new Exception("Veículo não foi encontrado...");
        //    }
        //}
        #endregion

        //(CREATE) Esse método vai adicionar o veículo na classe.
        public void AdicionarEntradaVeiculoLINQ(Veiculo veiculo)
        {
            var novoVeiculo = Veiculos.Where(Placa => Placa.Placa == veiculo.Placa).FirstOrDefault();
            if (novoVeiculo == null)
            {
                veiculo.HoraEntrada = DateTime.Now;
                Veiculos.Add(veiculo);
            }
            else
            {
                throw new Exception("Esse veículo já é existente, pois não foi cadastro sua saída.");
            }
        }

        //(DELETE) Cadastra a saída de um veículo 
        public void SaidaDeVeiculoLINQ(string placaveiculo)
        {
            var veiculoAchado = Veiculos.Where(veiculo => veiculo.Placa == placaveiculo).FirstOrDefault();

            if (veiculoAchado != null)
            {
                ImprimirVeieculo(veiculoAchado);
                Console.WriteLine("Deseja realmente registrar a saída do veículo acima? [1] SIM / [2] CANCELAR");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        veiculoAchado.HoraSaida = DateTime.Now;
                        double valorCobrado = 0;
                        var tempoPermanecido = veiculoAchado.HoraSaida - veiculoAchado.HoraEntrada;
                        if (veiculoAchado.TipoVeiculo == TipoVeiculo.Carro)
                        {
                            //Calculo da cobrança.
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
                            //valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 2.21;
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
                            //valorCobrado = Math.Ceiling(tempoPermanecido.TotalHours) * 1.24;
                        }
                        Console.WriteLine($"Valor total cobrado {valorCobrado:c}");
                        Faturamento += valorCobrado;
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
                throw new Exception("Veículo não encontrado...");
            }
        }

        //(READ) método que vai procurar o carro. Tem o paramatro que o usuário vai digitar.
        public Veiculo EncontrarVeiculoLINQ(string placaUsuario)
        {
            //Com o LINQ fazemos a mesma coisa, só que com menos linhas de código. 
            var veiculoAchado = Veiculos.Where(placa => placa.Placa == placaUsuario).FirstOrDefault();
            if (veiculoAchado == null)
            {
                throw new Exception("Veículo não encontrado... Tente outro");
            }
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
                    Console.WriteLine(ImprimirVeieculo(item));
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
                    Console.WriteLine(ImprimirVeieculo(item));
                }
            }
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        //(UPDATE) Alteração de veículo
        public Veiculo UpdateVeiculo(string placa, string proprietario, string modelo, string cor, string placaAlterada)
        {

            Veiculo veiculoEncontrado = Veiculos.Where(vei => vei.Placa == placa).FirstOrDefault();
            var veiculoSub = veiculoEncontrado;
            if (!(veiculoEncontrado == null))
            {
                Veiculos.Remove(veiculoEncontrado);
                veiculoSub.AlterarVeiculo(proprietario, modelo, cor, placaAlterada);
                Veiculos.Add(veiculoSub);
                return veiculoSub;
            }
            else
            {
                throw new Exception("Veículo não encontrado...");
            }
        }
        #endregion
    }
}