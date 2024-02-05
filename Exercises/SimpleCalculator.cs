using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Exercises {
    internal class SimpleCalculator {
        private delegate decimal Operation(List<decimal> nums);

        private static decimal Sum(List<decimal> nums) {
            return nums.Sum();
        }

        private static decimal Subtration(List<decimal> nums) {
            return nums.Aggregate((accum, current) => accum - current);
        }

        private static decimal Multiplication(List<decimal> nums) {
            return nums.Aggregate((accum, current) => accum * current);
        }

        private static decimal Divide(List<decimal> nums) {
            return nums.Aggregate((accum, current) => accum / current);
        }

        private static void Calculate(ref decimal totalRef, Operation operation) {
            bool continueAsking = true;
            List<decimal> nums = new();

            if (totalRef > 0)
                nums.Add(totalRef);

            Console.Clear();
            Console.WriteLine("Continue digitando para calcular os números: ");

            do {
                string msgTotal;
                string promptAnswer = Console.ReadLine();
                bool valueIsANumber = decimal.TryParse(promptAnswer, out decimal promptAnswerToDecimal);

                if (!valueIsANumber && promptAnswer.ToLower() == "q") {
                    totalRef = operation(nums);
                    msgTotal = "Total: " + totalRef;

                    Console.WriteLine(msgTotal);
                    Console.WriteLine(new string('-', msgTotal.Length));

                    continueAsking = false;
                } else if (valueIsANumber) {
                    nums.Add(promptAnswerToDecimal);
                    Console.WriteLine("Valores: {0}", string.Join(", ", nums));
                } else {
                    Console.WriteLine("[Erro] O valor precisa ser um número ou \"q\" para sair e calcular.");
                }
            } while (continueAsking);
        }

        private static void RenderAsciiArt() {
            Console.WriteLine(
                    " ________  ________  ___       ________     \r\n" +
                    "|\\   ____\\|\\   __  \\|\\  \\     |\\   ____\\    \r\n" +
                    "\\ \\  \\___|\\ \\  \\|\\  \\ \\  \\    \\ \\  \\___|    \r\n" +
                    " \\ \\  \\    \\ \\   __  \\ \\  \\    \\ \\  \\       \r\n" +
                    "  \\ \\  \\____\\ \\  \\ \\  \\ \\  \\____\\ \\  \\____  \r\n" +
                    "   \\ \\_______\\ \\__\\ \\__\\ \\_______\\ \\_______\\\r\n" +
                    "    \\|_______|\\|__|\\|__|\\|_______|\\|_______|");
        }

        private static void RenderMenuInitial(decimal initialValue) {
            RenderAsciiArt();
            if (initialValue > 0)
                Console.WriteLine("Valor atual: " + initialValue);

            Console.Write(
                    "Qual operação gostaria de fazer?\n" +
                    "1 - Somar\n" +
                    "2 - Subtrair\n" +
                    "3 - Multiplicar\n" +
                    "4 - Dividir\n" +
                    "5 - Sair\n"
                );
        }

        public static void Init() {
            bool continueAsking = true;
            decimal total = 0;

            do {
                RenderMenuInitial(total);

                bool answerIsANumber = int.TryParse(Console.ReadLine(), out int answer);

                Console.Clear();

                if (!answerIsANumber) {
                    Console.WriteLine("A opção digitada precisa ser um número.");
                } else {
                    switch (answer) {
                        case 1:
                            Calculate(ref total, Sum);
                            break;
                        case 2:
                            Calculate(ref total, Subtration);
                            break;
                        case 3:
                            Calculate(ref total, Multiplication);
                            break;
                        case 4:
                            Calculate(ref total, Divide);
                            break;
                        case 5:
                            Console.WriteLine("Resultado: " + total);
                            Console.WriteLine("Encerrando...");
                            continueAsking = false;
                            break;
                        default:
                            Console.WriteLine("Escolha apenas o número das opções listada.");
                            break;

                    }
                }
            } while (continueAsking);
        }
    }
}
