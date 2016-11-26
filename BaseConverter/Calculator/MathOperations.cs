namespace BaseConverter.Calculator
{
    internal static class MathOperations
    {
        public static int Add(int x, int y)
        {
            for (var carry = 0; y != 0; y = carry)
            {
                carry = (x & y) << 1;
                x = x ^ y;
            }

            return x;
        }

        public static int Sub(int x, int y)
        {
            y = Add(~y, 1);
            return Add(x, y);
        }

        public static int Mul(int x, int y)
        {
            int result = 0;
            for (int i = 0; i < y; i++)
            {
                result = Add(result, x);
            }
            return result;
        }

        public static int Div(int x, int y)
        {
            if (x < y || y == 0) return 0;

            int result = 0;
            y = Add(~y, 1);
            for (var res = x; res > 0; res = Add(res, y))
            {
                result = Add(result, 1);
            }
            return result;
        }
    }
}