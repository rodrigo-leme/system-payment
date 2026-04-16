using System;

namespace PaymentSystem.Payments
{
    /// <summary>
    /// Classe base para os pagamentos. Armazena o valor do pagamento e a data em que foi realizado.
    /// </summary>
    public abstract class Payment
    {
        /// <summary>
        /// Valor monetário do pagamento.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Data em que o pagamento foi processado.
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Construtor base que inicializa o valor e define a data do pagamento para o momento atual.
        /// </summary>
        /// <param name="value">Valor monetário do pagamento.</param>
        protected Payment(decimal value)
        {
            Value = value;
            PaymentDate = DateTime.Now;
        }

        /// <summary>
        /// Método abstrato que deve ser implementado pelas classes derivadas para processar o pagamento.
        /// </summary>
        /// <returns>Mensagem de confirmação contendo detalhes sobre a transação.</returns>
        public abstract string ProcessPayment();
    }
}