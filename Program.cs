using System;
using System.Globalization;
using PaymentSystem.Payments;

namespace PaymentSystem
{
    /// <summary>
    /// Classe principal que controla o fluxo da aplicação.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Ponto de entrada da aplicação. Exibe o menu e processa as escolhas do usuário.
        /// </summary>
        /// <param name="args">Argumentos de linha de comando (não utilizados).</param>
        private static void Main(string[] args)
        {
            bool sair = false;
            while (!sair)
            {
                Menu.ExibirMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ProcessarCartao();
                        break;
                    case "2":
                        ProcessarBoleto();
                        break;
                    case "3":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        /// <summary>
        /// Fluxo de processamento de pagamento via Cartão. Solicita valor e dados do cartão e exibe confirmação.
        /// </summary>
        private static void ProcessarCartao()
        {
            decimal valor = SolicitarValor();
            Console.WriteLine("Informe o número do cartão:");
            string numeroCartao = Console.ReadLine();
            var pagamento = new CardPayment(valor, numeroCartao);
            Console.WriteLine(pagamento.ProcessPayment());
            Console.WriteLine();
        }

        /// <summary>
        /// Fluxo de processamento de pagamento via Boleto. Solicita valor e código de barras e exibe confirmação.
        /// </summary>
        private static void ProcessarBoleto()
        {
            decimal valor = SolicitarValor();
            Console.WriteLine("Informe o código de barras:");
            string codigoBarras = Console.ReadLine();
            var pagamento = new BoletoPayment(valor, codigoBarras);
            Console.WriteLine(pagamento.ProcessPayment());
            Console.WriteLine();
        }

        /// <summary>
        /// Solicita ao usuário que informe um valor monetário e tenta parsear suportando diferentes culturas numéricas.
        /// </summary>
        /// <returns>O valor monetário informado pelo usuário.</returns>
        private static decimal SolicitarValor()
        {
            decimal valor;
            Console.WriteLine("Informe o valor do pagamento:");
            string entradaValor = Console.ReadLine();

            // Tenta fazer o parsing usando diferentes culturas para suportar variações de formato numérico
            var cultures = new[] { CultureInfo.CurrentCulture, new CultureInfo("pt-BR"), CultureInfo.InvariantCulture };
            bool parsed = false;
            valor = 0;

            foreach (var culture in cultures)
            {
                if (decimal.TryParse(entradaValor, NumberStyles.Currency | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out valor))
                {
                    parsed = true;
                    break;
                }
            }

            while (!parsed)
            {
                Console.WriteLine("Valor inválido. Tente novamente.");
                entradaValor = Console.ReadLine();
                foreach (var culture in cultures)
                {
                    if (decimal.TryParse(entradaValor, NumberStyles.Currency | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, culture, out valor))
                    {
                        parsed = true;
                        break;
                    }
                }
            }

            return valor;
        }
    }
}