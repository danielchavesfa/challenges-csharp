using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Exercises {
    internal class SimpleCalculator {
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

        public static void Init() {
            RenderAsciiArt();

            Console.WriteLine(
                "Qual operação gostaria de fazer?\n" +
                "1 - Somar\n" +
                "2 - Subtrair\n" +
                "3 - Multiplicar\n" +
                "4 - Dividir\n" +
                "5 - Sair");
        }
    }
}
