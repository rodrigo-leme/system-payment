using System;

namespace PaymentSystem.Payments
{
    /// <summary>
    /// Implementação de pagamento via Cartão de Crédito ou Débito.
    /// </summary>
    public class CardPayment : Payment
    {
        /// <summary>
        /// Número do cartão utilizado para o pagamento.
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CardPayment"/> com o valor e número do cartão.
        /// </summary>
        /// <param name="value">Valor monetário do pagamento.</param>
        /// <param name="cardNumber">Número do cartão.</param>
        public CardPayment(decimal value, string cardNumber) : base(value)
        {
            CardNumber = cardNumber;
        }

        /// <inheritdoc/>
        public override string ProcessPayment()
        {
            // Gera a mensagem de confirmação formatando o valor e a data conforme exigido
            return $"Processando pagamento de R$ {Value:0.00} via Cartão (Número: {CardNumber}) na data {PaymentDate:dd/MM/yyyy}.";
        }
    }
}