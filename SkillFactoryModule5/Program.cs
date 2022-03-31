// Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
// Имя;
// Фамилия;
// Возраст;
// Наличие питомца;
// Если питомец есть, то запросить количество питомцев;
// Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
// Запросить количество любимых цветов;
// Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
// Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
// Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
// Корректный ввод: ввод числа типа int больше 0.
//     Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
//     Вызов методов из метода Main.


namespace SkillFactoryModule5
{
    
    public static class Program
    {
        public static void Main()
        {
            PrintEverything(AskEverything());
        }

        public static (string firstName, string lastName, int age, string[] petsNames, string[] favoriteColors) AskEverything()
        {
            Console.WriteLine("Let me ask you some questions.");
            Console.WriteLine("Ok, let's start.");
            Console.WriteLine("The first question is what is your firstname?");
            var firstName = GetOneString();
            Console.WriteLine("and your lastname?");
            var lastName = GetOneString();
            Console.WriteLine($"Nice to meet you {lastName} {firstName}");

            Console.WriteLine($"What is your age?");
            var age = GetNumber();
            
            Console.WriteLine("Do you have a pet?");
            var withPet = false;
            var loopFlag = true;

            do
            {
                var answer = GetOneString().ToLower();
                switch (answer)
                {
                    case "yes":
                    case "y":
                        withPet = true;
                        loopFlag = false;
                        break;
                    case "no":
                    case "n":
                        withPet = false;
                        loopFlag = false;
                        break;
                    default:
                        Console.WriteLine("sorry, can you repeat? (answer yes or no)");
                        break;
                }
            } while (loopFlag);

            string[] petsNames;

            if (withPet)
            {
                Console.WriteLine("oh, really? And how many do you have?");
                var petsNumber = GetNumber();
                var str = petsNumber > 1
                    ? "Fascinating! Please tell me their names"
                    : "Fascinating! Please tell me its name";
                Console.WriteLine(str);
                petsNames = GetStrings(petsNumber);
            }
            else
            {
                petsNames = new [] {""};
            }
            
            Console.WriteLine("How many favorite colors do you have?");
            var colorsNumber = GetNumber();
            if (colorsNumber > 0)
            {
                Console.WriteLine("And what are they?");
            }
            var favoriteColors = GetStrings(colorsNumber);
            
            return (firstName, lastName, age,  petsNames, favoriteColors);
        }

        private static int GetNumber(int minNumber = 1)
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < minNumber)
            {
                Console.WriteLine("sorry, I didn't get your answer. Can you repeat? (you need to write a number)");
            }
            return number;
        }

        private static string[] GetStrings(int count)
        {
            var strings = new string[count];
            for (var i = 0; i < count; i++)
            {
                strings[i] = GetOneString();
            }
            return strings;
        }

        private static string GetOneString()
        {
            string str;
            do
            {
                str = Console.ReadLine() ?? "";
            } while (str == "");
            return str;
        }

        private static void PrintEverything(
            (string firstName, string lastName, int age, string[] petsNames, string[] favoriteColors) infoToPrint)
        {
            Console.WriteLine($"Your name is {infoToPrint.lastName} {infoToPrint.firstName} and your age is {infoToPrint.age}");
            var petsCount = infoToPrint.petsNames.Length;
            var str = (petsCount > 0) ? $"have {petsCount} pet" + (petsCount > 1 ? "s" :"") : "don't have pets\n";
            Console.Write($"Also I know that you {str}");
            if (petsCount > 0)
            {
                str = petsCount == 1 ? " and its name is " : " and their names are ";
                Console.Write(str);
                foreach (var petName in infoToPrint.petsNames)
                {
                    Console.Write(petName + " ");
                }
            }
            if (infoToPrint.favoriteColors.Length > 0)
            {
                str = infoToPrint.favoriteColors.Length == 1 ? "\nYour favorite color is " : "\nYour favorite colors are ";
                Console.Write(str);
                foreach (var favoriteColor in infoToPrint.favoriteColors)
                {
                    Console.Write(favoriteColor + " ");
                }
            }
        }
        
    }
}