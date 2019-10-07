namespace RPSLS_Avalonia.Services
{
    public static class RandomNumberGenerator
    {
        /// <summary>Generates a random number between min and max (inclusive).</summary>
        /// <param name="min">Inclusive minimum number</param>
        /// <param name="max">Inclusive maximum number</param>
        /// <param name="lowerLimit">Minimum limit for the method, regardless of min and max.</param>
        /// <param name="upperLimit">Maximum limit for the method, regardless of min and max.</param>
        /// <returns>Returns randomly generated integer between min and max with an upper limit of upperLimit.</returns>
        public static int GenerateRandomNumber(int min, int max, int lowerLimit = int.MinValue,
            int upperLimit = int.MaxValue)
        {
            if (min < lowerLimit)
                min = lowerLimit;
            if (max > upperLimit)
                max = upperLimit;
            int result = min < max
                ? ThreadSafeRandom.ThisThreadsRandom.Next(min, max + 1)
                : ThreadSafeRandom.ThisThreadsRandom.Next(max, min + 1);

            return result;
        }
    }
}