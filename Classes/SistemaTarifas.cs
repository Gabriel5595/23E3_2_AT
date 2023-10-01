using System;

namespace AT.Classes
{
    public class SistemaTarifas
    {
        public double ValorTotalSaldo { get; private set; }
        public double ValorTotalTarifa { get; private set; }

        public delegate void Callback(List<(string, double, double)> listaSaldosETarifas, string cpf, double ValorTotalSaldo, double ValorTotalTarifa);

        public void AdicionarConta(Conta conta)
        {
            ValorTotalSaldo += conta.SaldoAtualEmReais;

            if (conta is ITarifa contaComTarifa)
            {
                ValorTotalTarifa += contaComTarifa.CalcularTarifa();
            }
        }

        public void calcularValoresExternos(List<Cliente> listaClientes, List<(string CPF, double ValorTotalSaldo, double ValorTotalTarifa)> listaSaldosETarifas, Callback CompilaDadosClientes)
        {
            foreach (var cliente in listaClientes){
                ValorTotalSaldo = cliente.SaldoContaCorrente + (cliente.SaldoContaInternacional * 5) + (cliente.SaldoContaCripto *5 );

                ValorTotalTarifa = (cliente.SaldoContaCorrente * 1.015) + (cliente.SaldoContaInternacional * 1.025);

                CompilaDadosClientes(listaSaldosETarifas, cliente.CPF, ValorTotalSaldo, ValorTotalTarifa);
            }
        }

    }
}