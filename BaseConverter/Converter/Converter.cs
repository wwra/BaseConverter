namespace BaseConverter.Converter
{
    using System;

    internal static class Converter
    {
        private static string NBase = "0123456789ABCDEF";

        public static string FromDec(this string number, int toBase)
        {
            var data = number.Split('.');
            string result = string.Empty;

            for (var unit = int.Parse(data[0]); unit > 0; unit /= toBase)
            {
                result = NBase[unit % toBase] + result;
            }
            if (data.Length == 2)
            {
                var rest = "";

                for (var floatValue = double.Parse("0." + data[1]); floatValue > 0; floatValue *= toBase)
                {
                    int unitNum = (int)floatValue;
                    floatValue -= unitNum;
                    rest += NBase[unitNum];
                    if (rest.Length > 10) break; // for Infinity Numbers 0.446
                }

                if (rest.Length > 0) result += "." + rest;
            }

            return result;
        }

        public static string ToDec(this string number, int fromBase)
        {
            var data = number.Split('.');
            var result = 0.0;
            var value = data[0];
            int j = 0;

            for (var i = value.Length - 1; i >= 0; --i, ++j)
            {
                result += NBase.IndexOf(value[i]) * Math.Pow(fromBase, j);
            }

            if (data.Length == 2)
            {
                var floatValue = data[1];
                for (var i = 0; i < floatValue.Length; ++i)
                {
                    result += NBase.IndexOf(floatValue[i]) * Math.Pow(fromBase, -i - 1);
                }
            }

            return result.ToString();
        }
    }
}