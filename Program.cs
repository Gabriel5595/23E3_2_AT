using System;
using System.Collections.Generic;
using System.IO;

using AT.Classes;
class Program
{
    static void Main()
    {
        Console.Clear();

        SistemaTarifas sistema = new SistemaTarifas();

        List<Cliente> listaClientes = new List<Cliente>();

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção\n1 - Adicionar Conta Corrente\n2 - Adicionar Conta Internacional\n3 - Adicionar Conta Cripto\n4 - Ler Documento\n5 - Sair\n");
            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
                    Console.Write("Informe o saldo atual: ");
                    double saldoCorrente = double.Parse(Console.ReadLine());
                    ContaCorrente contaCorrente = new ContaCorrente(saldoCorrente);
                    sistema.AdicionarConta(contaCorrente);
                    break;

                case 2:
                    Console.Write("Informe o saldo atual: ");
                    double saldoInter = double.Parse(Console.ReadLine());
                    Console.Write("Informe a taxa de câmbio (USD para BRL): ");
                    double taxaCambio1 = double.Parse(Console.ReadLine());
                    ContaInternacional contaInternacional = new ContaInternacional(saldoInter, taxaCambio1);
                    sistema.AdicionarConta(contaInternacional);
                    break;

                case 3:
                    Console.Write("Informe o saldo atual: ");
                    double saldoCripto = double.Parse(Console.ReadLine());
                    Console.Write("Informe a taxa de câmbio (USD para BRL): ");
                    double taxaCambio2 = double.Parse(Console.ReadLine());
                    ContaCripto contaCripto = new ContaCripto(saldoCripto, taxaCambio2);
                    sistema.AdicionarConta(contaCripto);
                    break;
                
                case 4:
                    string caminhoArquivo = @"C:\Users\gribe\OneDrive\Documentos\Codes\INFNET\2023.2\Dados-Clientes.txt";//INSERIR O CAMINHO AQUI

                    try
                    {
                        using (StreamReader sr = new StreamReader(caminhoArquivo))
                        {
                            while (!sr.EndOfStream)
                            {
                                string linha = sr.ReadLine();
                                string[] dados = linha.Split('|');

                                if (dados.Length == 5)
                                {
                                    Cliente cliente = new Cliente
                                    (
                                        dados[0],
                                        dados[1],
                                        double.Parse(dados[2]),
                                        double.Parse(dados[3]),
                                        double.Parse(dados[4])
                                    );

                                    listaClientes.Add(cliente);
                                }
                                else
                                {
                                    Console.WriteLine($"A linha '{linha}' não contém todas as informações necessárias e será ignorada.\n");
                                }
                            }
                        }

                        Console.WriteLine("As seguintes informações foram extraídas do documento apresentado:\n");

                        foreach (var cliente in listaClientes)
                        {
                            Console.WriteLine($"CPF: {cliente.CPF}, Nome: {cliente.Nome}, Saldo Corrente: {cliente.SaldoContaCorrente}, Saldo Internacional: {cliente.SaldoContaInternacional}, Saldo Cripto: {cliente.SaldoContaCripto}");
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                        break;
                    }

                case 5:
                    Console.WriteLine($"Total do Saldo: {sistema.ValorTotalSaldo} reais");
                    Console.WriteLine($"Total da Tarifa: {sistema.ValorTotalTarifa} reais");
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}