using System;

namespace AT.Classes
{
    public class ContaInternacional : Conta, ITarifa
    {
        public double TaxaCambio { get; private set; }

        public ContaInternacional(double saldoAtualEmDolares, double taxaCambio) : base(saldoAtualEmDolares)
        {
            TaxaCambio = taxaCambio;
            SaldoAtualEmReais = saldoAtualEmDolares * taxaCambio;
        }

        public double Calcular()
        {
            return SaldoAtualEmReais * 0.025;
        }
    }
}