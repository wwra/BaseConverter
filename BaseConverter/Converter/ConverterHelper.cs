namespace BaseConverter.Converter
{
    internal static class ConverterHelper
    {
        public static string NegativeBin(this string bin, bool isSign)
        {
            // TODO: Create carry for reducing Remove/Add sign
            if (bin.Length%8 == 0) bin = bin.RemoveSignFromBin();
            bin = AddOneToBin(InvertBin(bin));
            return bin.AddSignToBin(isSign);
        }

        public static string ReverseNegativeBin(this string bin)
        {
            // TODO: Create carry for reducing Remove/Add sign
            if (bin.Length%8 == 0) bin = bin.RemoveSignFromBin();
            bin = InvertBin(bin);
            return "0" + bin;
        }

        public static string NormalizeUnitResult(this string result)
        {
            var data = result.Split('.');
            result = data[0].PadLeft(CountZero(data[0]), '0');
            if (data.Length == 2) result += "." + data[1];

            return result;
        }

        public static string SubOneFromDec(this string number)
        {
            //TODO: Create Binary Sum Method
            return (double.Parse(number) - 1).ToString();
        }

        public static string AddSignToBin(this string number, bool isNegative)
        {
            return isNegative ? "1" + number : "0" + number;
        }

        private static string RemoveSignFromBin(this string number)
        {
            return number.Substring(1);
        }

        private static string InvertBin(this string bin)
        {
            string result = string.Empty;
            int length = bin.Length;
            for (int i = 0; i < length; ++i)
            {
                int rank = bin[i] - '0';
                result += rank == 1 ? 0 : 1;
            }

            return result;
        }

        private static string AddOneToBin(this string inverted)
        {
            string result = string.Empty;

            int length = inverted.Length - 1;
            int nextRank = 1;
            for (int i = length; i >= 0; --i)
            {
                int rank = (inverted[i] - '0') + nextRank;
                result = rank%2 == 0 ? 0 + result : 1 + result;
                nextRank = rank > 1 ? 1 : 0;
            }

            return result;
        }

        private static int CountZero(string number)
        {
            return number.Length < 8 ? 7 : 8*(number.Length/8) + 7;
        }
    }
}