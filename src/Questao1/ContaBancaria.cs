using System;

namespace Questao1
{
    public class ContaBancaria {

        public int NumeroConta { get; private set; }
        public string Nome { get; private set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string nome, double depositoInicial = 0.00)
        {
            SetNumeroConta(numeroConta);
            SetNome(nome);
            RealizaDeposito(depositoInicial);
        }

        public void SetNumeroConta(int numeroConta)
        {
            if (numeroConta <= 0)
            {
                throw new ArgumentException("Número da conta inválido");
            }
            NumeroConta = numeroConta;
        }

        public void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome deve ser informado");
            }
            Nome = nome;
        }

        public void RealizaDeposito(double quantia)
        {
            if (quantia < 0)
            {
                throw new ArgumentException("O valor não pode ser negativo");
            }

            Saldo += quantia;
        }

        public void RealizaSaque(double quantia)
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
            => $"Conta {NumeroConta}, Titular: {Nome}, Saldo: $ {string.Format("{0:N2}", Saldo)}";
    }
}
