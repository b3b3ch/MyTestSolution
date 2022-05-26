namespace MySolution.Common.Extensions
{
    public static class ArrayExtensions
    {
        public static int SumArguments(this int[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException("Array can't be null or empty!");
            }

            return args.Sum();
        }
    }
}