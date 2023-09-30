using System;
using System.Collections.Generic;
using System.IO;

using AT.Classes;
class Program
{
    static void Main()
    {
        SistemaTarifas sistema = new SistemaTarifas();

        List<Cliente> listaClientes = new List<Cliente>();

        while (true)
        {
            Console.WriteLine("Escolha o tipo de conta (1 - Conta Corrente\n2 - Conta Internacional\n3 - Conta Cripto\n4 - Ler Documento\n5 - Sair):");
            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
                    Console.Write("Informe o saldo atual: ");
                    double saldo = double.Parse(Console.ReadLine());
                    ContaCorrente contaCorrente = new ContaCorrente(saldo);
                    sistema.AdicionarConta(contaCorrente);
                    break;

                case 2:
                    Console.Write("Informe o saldo atual: ");
                    double saldo = double.Parse(Console.ReadLine());
                    Console.Write("Informe a taxa de câmbio (USD para BRL): ");
                    double taxaCambio1 = double.Parse(Console.ReadLine());
                    ContaInternacional contaInternacional = new ContaInternacional(saldo, taxaCambio1);
                    sistema.AdicionarConta(contaInternacional);
                    break;

                case 3:
                    Console.Write("Informe o saldo atual: ");
                    double saldo = double.Parse(Console.ReadLine());
                    Console.Write("Informe a taxa de câmbio (USD para BRL): ");
                    double taxaCambio2 = double.Parse(Console.ReadLine());
                    ContaCripto contaCripto = new ContaCripto(saldo, taxaCambio2);
                    sistema.AdicionarConta(contaCripto);
                    break;
                
                case 4:
                    string caminhoArquivo = null;//INSERIR O CAMINHO AQUI

                    try
                    {
                        using (StreamReader sr = new StreamReader(caminhoArquivo))
                        {
                            while (!sr.EndofStream)
                            {
                                string linha = sr.ReadLine();
                                string[] dados = linha.Split(' | ');

                                if (dados.Lenght == 5)
                                {
                                    Cliente cliente = new Cliente
                                    {
                                        CPF = dados[0],
                                        Nome = dados[1],
                                        SaldoContaCorrente = double.Parse(dados[2]),
                                        SaldoContaInternacional = double.Parse(dados[3]),
                                        SaldoContaCripto = double.Parse(dados[4])
                                    };

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
                    }

                case 5:
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        Console.WriteLine($"Total do Saldo: {sistema.ValorTotalSaldo} reais");
        Console.WriteLine($"Total da Tarifa: {sistema.ValorTotalTarifa} reais");
    }
}