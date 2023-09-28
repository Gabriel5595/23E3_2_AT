using System;

namespace AT.Classes
{
    public class SistemaTarifas
    {
        public double ValorTotalSaldo { get; private set; }
        public double ValorTotalTarifa { get; private set; }

        public void AdicionarConta(Conta conta)
        {
            ValorTotalSaldo += conta.SaldoAtualEmReais;

            if (conta is ITarifa contaComTarifa)
            {
                ValorTotalTarifa += contaComTarifa.Calcular();
            }
        }
    }
}