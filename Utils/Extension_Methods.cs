using System;

namespace Utils
{
    public static class Extension_Methods
    {
        public static double GetDoubleBetweenRange(this Random rand, double min, double max)
        {
            return rand.NextDouble() * (max - min) + min;
        }
    }
}
