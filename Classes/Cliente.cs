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

        public Clientes(string cpf, string nome, double SaldoContaCorrent, double SaldoContaInternacional, double SaldoContaCripto)
        {
            this.CPF = cpf;
            this.Nome = nome;
            this.SaldoContaCorrente = SaldoContaCorrente;
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