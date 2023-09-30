using System;

namespace AT.Classes
{
    public class Cliente
    {
        public string CPF { get; private set; }
        public string Nome { get; private set; }
        public double SaldoContaCorrente { get;private  set; }
        public double SaldoContaInternacional { get; private set; }
        public double SaldoContaCripto { get; private set; }

        public Cliente(string cpf, string nome, double saldoContaCorrente, double saldoContaInternacional, double saldoContaCripto)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.SaldoContaCorrente = saldoContaCorrente;
            this.SaldoContaInternacional = saldoContaInternacional;
            this.SaldoContaCripto = saldoContaCripto;
        }


        //criar três listas:
            //listaCpfCorrent
            //listacpfInter
            //listacpfCripto
        
        //criar método que adicionar os atributos a cada uma das três listas

    }
}