using System;

namespace AT.Classes
{
    public class ContaCorrente : Conta, ITarifa
    {
        public ContaCorrente(double saldoAtualEmReais) : base(saldoAtualEmReais) { }
        
        public double CalcularTarifa()
        {
            return SaldoAtualEmReais * 0.015;
        }
    }
}