using Projeto_Estacionamento.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estacionamento.MenuPrincipal
{
    public class Menu
    {

        Patio estacionamento = new Patio();

        public void MenuPrincipal()
        {
            bool parar = true;
            do
            {
                try
                {


                    Console.Clear();
                    Console.WriteLine("(1) Registrar entrada\n(2) Gegistrar saída\n(3) Exibir faturamenro\n(4) Mostrar veículos estacionados\n(5) Procurar Veículo\n(6) Mostrar apenas carros estacionados\n(7) Mostrar apenas motos estacionados\n(8) Alterar veículo\n(9) Sair da aplicação");
                    Console.Write("Escolha uma das opções: ");
                    string opcao = Console.ReadLine();
                    switch (opcao)
                    {
                        case "1":
                            Console.Clear();
                            AdicionarVeiculo();
                            Console.ReadKey();
                            break;
                        case "2":
                            Console.Clear();
                            SaidaDeVeiculoLINQ();
                            Console.ReadKey();
                            break;
                        case "3":
                            Console.Clear();
                            estacionamento.FaturamentoTotal();
                            Console.ReadKey();
                            break;
                        case "4":
                            Console.Clear();
                            VeiculosEstacionados();
                            Console.ReadKey();
                            break;
                        case "5":
                            Console.Clear();
                            AcharVeiculo();
                            Console.ReadKey();
                            break;
                        case "6":
                            Console.Clear();
                            estacionamento.ImprimirCarros();
                            Console.ReadKey();
                            break;
                        case "7":
                            Console.Clear();
                            estacionamento.ImprimirMotos();
                            Console.ReadKey();
                            break;
                        case "8":
                            Console.Clear();
                            AlterarDadosVeiculo();
                            Console.ReadKey();
                            break;
                        case "9":
                            Console.WriteLine("Saindo...");
                            Thread.Sleep(2000);
                            parar = false;
                            break;
                        default:
                            Console.WriteLine("Opção inválida! Tente outra...");
                            Console.ReadKey();
                            break;
                    }

                }
                catch (ArgumentException exArgu)
                {
                    Console.WriteLine(exArgu.Message);
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro: " + ex.Message);
                    Console.ReadKey();
                }
            } while (parar);
        }

        //Escolhe se vai adicionar a moto ou o carro.
        public void AdicionarVeiculo()
        {
            bool parar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Deseja adicionar 1 - Carro / 2 - Moto / 3 Cancelar");
                Console.Write("Opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        AdicionarCarro();
                        parar = false;
                        break;
                    case "2":
                        Console.Clear();
                        AdicionarMoto();
                        parar = false;
                        break;
                    case "3":
                        MenuPrincipal();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (parar);
        }

        //Método que adiciona um carro na lista de veículos.
        public void AdicionarCarro()
        {
            Veiculo carro = new Veiculo();
            //Aqui adicionamos o tipo que esse veículo é.
            carro.TipoVeiculo = TipoVeiculo.Carro;
            Console.WriteLine("========== CADASTRO DE CARROS ==========");

            Console.Write("Proprietário: ");
            carro.Proprietario = Console.ReadLine();

            Console.Write("Placa: ");
            carro.Placa = Console.ReadLine().ToUpper();

            Console.Write("Modelo: ");
            carro.Modelo = Console.ReadLine();

            Console.Write("Cor: ");
            carro.Cor = Console.ReadLine();
            carro.HoraEntrada = DateTime.Now;

            Console.WriteLine("\nDeseja realmente adicionar os dados acima? [1]Sim / [2]Não");
            Console.Write("Opção: ");
            int escolhaAdicionar = Convert.ToInt32(Console.ReadLine());
            switch (escolhaAdicionar)
            {
                case 1:
                    estacionamento.AdicionarEntradaVeiculoLINQ(carro);
                    Console.WriteLine($"Carro de {carro.Proprietario} adicionado com sucesso!");
                    break;
                case 2:
                    Console.WriteLine("Operação cancelada");
                    break;
                default:
                    Console.WriteLine("Opcão inválida");
                    break;
            }
        }

        //Adiciona a moto na lista de veículos.
        public void AdicionarMoto()
        {
            Veiculo moto = new Veiculo();
            moto.TipoVeiculo = TipoVeiculo.Moto;
            Console.WriteLine("========== CADASTRO DE MOTOS  ==========");

            Console.Write("Proprietário: ");
            moto.Proprietario = Console.ReadLine();

            Console.Write("Placa: ");
            moto.Placa = Console.ReadLine().ToUpper();

            Console.Write("Modelo: ");
            moto.Modelo = Console.ReadLine();

            Console.Write("Cor: ");
            moto.Cor = Console.ReadLine();
            moto.HoraEntrada = DateTime.Now;

            Console.WriteLine("\nDeseja realmente adicionar o veículo acima [1] Sim / [2] Cancelar");
            Console.Write("Opção: ");
            int escolha = Convert.ToInt32(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    Console.WriteLine($"Moto do(a) {moto.Proprietario} adicionado com sucesso!");
                    estacionamento.AdicionarEntradaVeiculoLINQ(moto);
                    break;
                case 2:
                    Console.WriteLine("Operação cancelada.");
                    break;
                default:
                    Console.WriteLine("Opcção inválida");
                    break;
            }
        }

        //Cadastra a saída dos veículos
        public void SaidaDeVeiculoLINQ()
        {
            bool quebra = true;
            Console.WriteLine("========== SAÍDA DE CARROS ==========");
            do
            {
                Console.Clear();
                Console.WriteLine("Adicionar saída de um veículo [1] SIM / [2] NÃO");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite a placa do veículo: ");
                        string placa = Console.ReadLine().ToUpper();
                        //Veiculo saidaVeiculo = new Veiculo();
                        estacionamento.SaidaDeVeiculoLINQ(placa);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case "2":
                        MenuPrincipal();
                        quebra = false;
                        break;
                    default:
                        Console.WriteLine("Opção incorreta");
                        Console.ReadKey();
                        break;
                }
            } while (quebra);
        }

        //Imprime todos os veículos
        public void VeiculosEstacionados()
        {
            Console.WriteLine("=-=-=-=-=-= VEÍCULOS ESTACINADOS =-=-=-=-=-=\n");

            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            foreach (var item in estacionamento.Veiculos)
            {
                Console.WriteLine(estacionamento.ImprimirVeieculo(item));
            }
            Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }

        //Método que vai imprimir o veículo procurado.
        public void AcharVeiculo()
        {
            Console.WriteLine("=-=-=-=-=-= PESQUISAR VEÍCULO =-=-=-=-=-=");
            Console.Write("Digite a placa: ");
            string placa = Console.ReadLine();

            Console.WriteLine(estacionamento.ImprimirVeieculo(estacionamento.EncontrarVeiculoLINQ(placa)));
        }

        public void AlterarDadosVeiculo()
        {
            bool parar = true, quebraPrincipal = true;
            Console.WriteLine("=-=-=-=-=-= ALTERAR VEÍCULO =-=-=-=-=-=");
            do
            {
                Console.Clear();
                Console.Clear();
                Console.WriteLine("[1] Alterar os dados de um veículo / [2] Cancelar");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        do
                        {
                            Console.Write("Digite a placa: ");
                            string placa = Console.ReadLine();
                            var veiculoEncontrado = estacionamento.EncontrarVeiculoLINQ(placa);
                            Console.WriteLine(estacionamento.ImprimirVeieculo(estacionamento.EncontrarVeiculoLINQ(placa)));
                            if (veiculoEncontrado != null)
                            {
                                Console.WriteLine("Agora digite a alteração");
                                Console.Write("Proprietário: ");
                                string proprietario = Console.ReadLine();

                                Console.Write("Placa: ");
                                string placaAlterar = Console.ReadLine();

                                Console.Write("Modelo: ");
                                string modelo = Console.ReadLine();

                                Console.Write("Cor: ");
                                string cor = Console.ReadLine();

                                if (placaAlterar == "" || proprietario == "" || modelo == "" || cor == "")
                                {
                                    Console.WriteLine("Se deve preencher o formulário inteiro... Tente novamente");
                                }
                                else
                                {
                                    estacionamento.UpdateVeiculo(placa, proprietario, modelo, cor, placaAlterar);
                                    parar = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Veículo não encontrado... Tente outro.");
                            }
                        } while (parar);
                        Console.WriteLine("Veículo alterado com sucesso!");
                        quebraPrincipal = false;
                        break;
                    case "2":
                        quebraPrincipal = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        Console.ReadKey();
                        break;
                }
            } while (quebraPrincipal);
        }
    }
}
