using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges.Exercises {
    internal class MultiplicationTable {
        public static void Init() {
            Console.Write("Digite o número para ver sua tabuada: ");
            int chosenNumber = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i <= 10; i++) {
                Console.WriteLine($"{chosenNumber} x {i,2} = {chosenNumber * i}");
            }
        }
    }
}
