using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Exercises {
    internal enum Menu {
        QUIT, BINARY, DECIMAL, HEXADECIMAL
    }

    internal class BinaryConverter {
        private delegate string ConvertTo(byte b);

        private static string ConvertString(string text, ConvertTo convert) {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            string binaryText = "";

            foreach (byte b in bytes) {
                binaryText += $"{convert(b)} ";
            }

            return binaryText;
        }

        private static string ConvertBinary(byte b) {
            return Convert.ToString(b, 2).PadLeft(8, '0');
        }

        private static string ConvertDecimal(string text) {
            string textConvertedToBinary = ConvertString(text, ConvertBinary);
            string[] textConvertedToBinarySplited = textConvertedToBinary.Split(' ');
            int decimalValue = 0;
            
            foreach (string textBinary in textConvertedToBinarySplited) {
                for (int i = textBinary.Length - 1; i >= 0; i--) {
                    int bit = textBinary[i] - '0';

                    decimalValue += bit * (int) Math.Pow(2, textBinary.Length - 1 - i);
                }
            }

            return decimalValue.ToString();
        }

        private static string ConvertHex(byte b) {
            return b.ToString("X2");
        }

        public static void Init() {
            Console.Write("Digite o texto para codificar: ");
            string promptAnswerToConvert = Console.ReadLine();

            if (string.IsNullOrEmpty(promptAnswerToConvert)) {
                Console.WriteLine("[Erro] Texto inválido. Digite uma frase ou letra para codificar.");
                return;
            }

            Console.WriteLine(
                    "Escolha o decodificador:\n" +
                    "1 - Binário\n" +
                    "2 - Decimal\n" +
                    "3 - Hexadecimal\n" +
                    "0 - Sair"
                );

            bool answerIsANumber = int.TryParse(Console.ReadLine(), out int promptAnswerOptions);

            if (!answerIsANumber) {
                Console.Clear();
                Console.WriteLine("Opção inválida!");
                Environment.Exit(13);
            }

            switch (promptAnswerOptions) {
                case (int)Menu.QUIT:
                    Console.WriteLine("Encerrando...");
                    Environment.Exit(0);
                    break;
                case (int)Menu.BINARY:
                    Console.WriteLine("Resultado: {0}", ConvertString(promptAnswerToConvert, ConvertBinary));
                    break;
                case (int)Menu.DECIMAL:
                    Console.WriteLine(ConvertDecimal(promptAnswerToConvert));
                    break;
                case (int)Menu.HEXADECIMAL:
                    Console.WriteLine("Resultado: {0}", ConvertString(promptAnswerToConvert, ConvertHex));
                    break;
                default:
                    Environment.Exit(13);
                    break;
            }
        }
    }
}
