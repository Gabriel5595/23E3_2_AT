using System;

namespace AT.Classes
{
    public class ContaCripto : Conta, ITarifa
    {
        public double TaxaCambio { get; private set; }

        public ContaCripto(double saldoAtualEmDolares, double taxaCambio) : base(saldoAtualEmDolares * taxaCambio) 
        {
            TaxaCambio = taxaCambio;
            SaldoAtualEmReais = saldoAtualEmDolares * taxaCambio;
        }

        public double CalcularTarifa()
        {
            return SaldoAtualEmReais * 0.025;
        }
    }
}