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
        List<(string CPF, double ValorTotalSaldo, double ValorTotalTarifa)> listaSaldosETarifas = new List<(string, double, double)>();
        Arquivo arquivo = new Arquivo(listaClientes, listaSaldosETarifas);

        while (true)
        {
            Console.WriteLine("\nEscolha uma opção\n1 - Ler Documento\n2 - Gerar dados de Tarifas\n3 - Exportar dados de Saldos e Tarifas\n4 - Sair\n");
            int escolha = int.Parse(Console.ReadLine());
            
            switch (escolha)
            {
                case 1:
                    listaClientes = arquivo.RecebeDados();
                    break;

                case 2:
                    sistema.calcularValoresExternos(listaClientes, listaSaldosETarifas, (List<(string CPF, double ValorTotalSaldo, double ValorTotalTarifa)> listaSaldosETarifas, string cpf, double ValorTotalSaldo, double ValorTotalTarifa) => {
                        listaSaldosETarifas.Add((cpf, ValorTotalSaldo, ValorTotalTarifa));
                        Console.WriteLine($"Os valores CPF: {cpf}, Saldo: {ValorTotalSaldo:F2} e Tarifa: {ValorTotalTarifa:F2} foram adicionados com sucesso!");
                    });
                    break;

                case 3:
                    foreach(var dadosCliente in listaSaldosETarifas)
                    {
                        arquivo.GeraArquivos(dadosCliente);
                    }
                    break;
                    
                    
                case 4:
                    return;

                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
    }
}