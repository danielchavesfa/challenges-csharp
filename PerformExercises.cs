using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenges {
    internal class PerformExercises {
        private static bool VerifyIfListIsEmptyToStartProgram(Dictionary<string, Action> exercisesList) {
            if (exercisesList == null || exercisesList.Count == 0) {
                Console.WriteLine("Lista de exercícios está vazia. :(");
                return true;
            } else {
                return false;
            }
        }

        private static void ChangeFontColorAndThenClean(string message, ConsoleColor consoleColor) {
            Console.ForegroundColor = consoleColor;
            Console.Write(message);
            Console.ResetColor();
        }

        private static void ListAllExercises(Dictionary<string, Action> exercisesList) {
            int countExercise = 1;

            ChangeFontColorAndThenClean("Lista de exercícios:\n", ConsoleColor.Green);

            foreach (var exercise in exercisesList) {
                ChangeFontColorAndThenClean($"{countExercise}", ConsoleColor.Red);
                Console.WriteLine($" - {exercise.Key}");
                countExercise++;
            }
        }

        private static int AskForExerciseNumber() {
            Console.Write("Digite o ");
            ChangeFontColorAndThenClean("número", ConsoleColor.Red);
            Console.Write(" do exercício para carrega-lo ou nada para carregar o último: ");
            _ = int.TryParse(Console.ReadLine(), out int choiceOfExercise);

            return choiceOfExercise;
        }

        public static void Init(Dictionary<string, Action> exercisesList) {
            if (VerifyIfListIsEmptyToStartProgram(exercisesList)) 
                return;

            ListAllExercises(exercisesList);

            int choiceOfExercise = AskForExerciseNumber();
            bool choiceExerciseIsLessThanZero = choiceOfExercise < 1;
            bool choiceExerciseIsGreaterThanExerciseListCount = choiceOfExercise > exercisesList.Count;

            Console.Clear();

            if (choiceExerciseIsLessThanZero || choiceExerciseIsGreaterThanExerciseListCount) {
                exercisesList.ElementAt(exercisesList.Count - 1).Value();
            } else {
                exercisesList.ElementAt(choiceOfExercise - 1).Value();
            }
        }
    }
}
