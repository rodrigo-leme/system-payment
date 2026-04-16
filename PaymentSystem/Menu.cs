using System;

namespace PaymentSystem
{
    /// <summary>
    /// Classe estática responsável por exibir o menu principal da aplicação.
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// Exibe o menu de opções ao usuário.
        /// </summary>
        public static void ExibirMenu()
        {
            Console.WriteLine("***** Sistema de Processamento de Pagamentos *****");
            Console.WriteLine("********** Escolha a forma de pagamento **********");
            Console.WriteLine("1 - Cartão");
            Console.WriteLine("2 - Boleto");
            Console.WriteLine("3 - Sair");
            Console.WriteLine("Escolha uma opção:");
        }
    }
}