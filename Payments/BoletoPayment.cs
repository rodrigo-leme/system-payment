using System;

namespace PaymentSystem.Payments
{
    /// <summary>
    /// Implementação de pagamento via Boleto Bancário.
    /// </summary>
    public class BoletoPayment : Payment
    {
        /// <summary>
        /// Código de barras do boleto.
        /// </summary>
        public string Barcode { get; set; }

        /// <summary>
        /// Inicializa uma nova instância de <see cref="BoletoPayment"/> com o valor e código de barras.
        /// </summary>
        /// <param name="value">Valor monetário do pagamento.</param>
        /// <param name="barcode">Código de barras do boleto.</param>
        public BoletoPayment(decimal value, string barcode) : base(value)
        {
            Barcode = barcode;
        }

        /// <inheritdoc/>
        public override string ProcessPayment()
        {
            // Gera a mensagem de confirmação formatando o valor e a data conforme exigido
            return $"Processando pagamento de R$ {Value:0.00} via Boleto (Cod Barra: {Barcode}) na data {PaymentDate:dd/MM/yyyy}.";
        }
    }
}