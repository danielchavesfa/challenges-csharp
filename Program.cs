using Challenges.Exercises;

namespace Challenges {
    internal class Program {
        static void Main(string[] args) {
            Dictionary<string, Action> exercises = new() {
                { "Tabuada", MultiplicationTable.Init },
                { "Calculadora Simples", SimpleCalculator.Init },
                { "Conversor para Binário", BinaryConverter.Init },
            };

            PerformExercises.Init(exercises);
        }
    }
}
