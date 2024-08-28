using System;

namespace Questao1
{
    public class ContaBancaria {

        public int NumeroConta { get; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string nome, double depositoInicial = 0.00)
        {
            Nome = nome;
            NumeroConta = numeroConta;
            Saldo = depositoInicial;
        }

        public void Deposito(double quantia)
        {
            if (quantia < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo");
            }

            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            const double taxa = 3.50;

            if (quantia < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo");
            }

            Saldo -= quantia;
            Saldo -= taxa;
        }

        public override string ToString()
            => $"Conta {NumeroConta}, Titular: {Nome}, Saldo: $ {string.Format("{0:C}", Saldo)}";
    }
}
