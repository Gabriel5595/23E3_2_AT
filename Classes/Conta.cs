using System;

namespace AT.Classes
{
    public abstract class Conta
    {
        public double SaldoAtualEmReais { get; protected set; }

        public Conta(double saldoAtualEmReais)
        {
            SaldoAtualEmReais = saldoAtualEmReais;
        }
    }
}

