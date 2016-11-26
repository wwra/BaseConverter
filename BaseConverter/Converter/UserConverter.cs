namespace BaseConverter.Converter
{
    using System;

    internal static class UserConverter
    {
        public static void ShowConsole()
        {
            // TODO: User Input Exception handling
            Manual();
            do
            {
                Console.WriteLine("Enter number");
                var number = Console.ReadLine();
                Console.WriteLine("Is it negative? YES == 1 ; NO == 0");
                var isSign = Console.ReadLine() == "1";
                Console.WriteLine("Enter base from");
                var fromBase = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter base to");
                var toBase = int.Parse(Console.ReadLine());

                UserControl(number, fromBase, toBase, isSign);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }

        private static void UserControl(string number, int fromBase, int toBase, bool isSign)
        {
            var result = !isSign
                ? MumboJumboPositiveLogic(number, fromBase, toBase, isSign)
                : MumboJumboNegativeLogic(number, fromBase, toBase, isSign);

            Console.WriteLine("{0}", isSign ? "(-) " + result : result);
        }

        private static string MumboJumboPositiveLogic(string number, int fromBase, int toBase, bool isSign)
        {
            if (fromBase == 10)
                if (toBase == 2) return number.FromDec(toBase).NormalizeUnitResult().AddSignToBin(isSign);
                else return number.FromDec(toBase);
            return number.ToDec(fromBase);
        }

        private static string MumboJumboNegativeLogic(string number, int fromBase, int toBase, bool isSign)
        {
            string result;
            if (fromBase == 2)
                result =
                    number.Substring(1).ToDec(2).SubOneFromDec().FromDec(2).NormalizeUnitResult().ReverseNegativeBin();
            else
            {
                if (fromBase == 10) result = number.FromDec(2).NormalizeUnitResult().NegativeBin(isSign);
                else result = number.ToDec(fromBase).FromDec(2).NormalizeUnitResult().NegativeBin(isSign);
            }

            return toBase == 2 ? result : toBase == 10 ? result.ToDec(2) : result.ToDec(2).FromDec(toBase);
        }

        private static void Manual()
        {
            Console.WriteLine("Manual:");
            Console.WriteLine();
            Console.WriteLine("BIN: ");
            Console.WriteLine("Positive: (0)0000000 == 8 '0' including sign");
            Console.WriteLine("Negative: (1)0000000 == 1 '1' && 7 '0' including sign");
            Console.WriteLine();
        }
    }
}