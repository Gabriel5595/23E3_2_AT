using System;

namespace AT.Classes
{
    public abstract class Conta
    {
        public virtual double SaldoAtualEmReais { get; protected set; }

        public Conta(double saldoAtualEmReais)
        {
            this.SaldoAtualEmReais = saldoAtualEmReais;
        }
    }
}

