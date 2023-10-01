using System;
using System.Collections.Generic;
using System.IO;

namespace AT.Classes
{
    public class Arquivo
    {
        public List<Cliente> ListaClientes { get; private set; }
        public List<(string CPF, double ValorTotalSaldo, double ValorTotalTarifa)> ListaSaldosETarifas { get; private set; }

        public Arquivo (List<Cliente> listaClientes, List<(string CPF, double ValorTotalSaldo, double ValorTotalTarifa)> listaSaldosETarifas)
        {
            ListaClientes = listaClientes;
            ListaSaldosETarifas = listaSaldosETarifas;
        }

        public List<Cliente> RecebeDados()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            
            string caminhoArquivo = @"C:\Users\gribe\OneDrive\Documentos\Codes\INFNET\2023.2\Dados-Clientes.txt";

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
            
            Console.WriteLine("As seguintes informações foram extraídas do documento apresentado:\n");

            foreach (var cliente in listaClientes)
            {
                Console.WriteLine($"CPF: {cliente.CPF}, Nome: {cliente.Nome}, Saldo Corrente: {cliente.SaldoContaCorrente}, Saldo Internacional: {cliente.SaldoContaInternacional}, Saldo Cripto: {cliente.SaldoContaCripto}");
            }

            return listaClientes;
        }

        public void GeraArquivos((string CPF, double ValorTotalSaldo, double ValorTotalTarifa) dados)
        {
            string nomeArquivo = $"{dados.CPF}.txt";
            string conteudoArquivo = $"{dados.ValorTotalSaldo:F2} | {dados.ValorTotalTarifa:F2}";
            string caminhoArquivoNovo = @"C:\Users\gribe\OneDrive\Documentos\Codes\INFNET\2023.2";
            string caminhoCompleto = Path.Combine(caminhoArquivoNovo, nomeArquivo);
            File.WriteAllText(caminhoCompleto, conteudoArquivo);
        }
    }
}