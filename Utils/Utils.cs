using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public static class Util
    {
        static Random rand = new Random();
        public static Random Rand { get => rand; }

        public static float GetRandomFromRange(double min, double max)
        {
            return (float)(rand.NextDouble() * (max - min) + min);
        }
    }
}
