// ReSharper disable MemberCanBePrivate.Global
namespace ItemGenerator.Util
{
    public class RandomUtil
    {
        private readonly Random _random = new();

        private const double Tolerance = 0.0001f;

        public int Next(int max)
        {
            return _random.Next(max);
        }

        public int Next(int min, int max)
        {
            return min == max ? min : _random.Next(min, max);
        }

        public double Next(double max)
        {
            return _random.NextDouble() * max;
        }

        public double Next(double min, double max)
        {
            if (Math.Abs(min - max) < Tolerance)
                return min;

            return _random.NextDouble() * (max - min) + min;
        }


        public float Next(float max)
        {
            return (float)_random.NextDouble() * max;
        }

        public float Next(float min, float max)
        {
            if (Math.Abs(min - max) < Tolerance)
                return min;

            return (float)_random.NextDouble() * (max - min) + min;
        }

        public void Shuffle<T>(IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = _random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public T? Pick<T>(IList<T> list) where T : class
        {
            return list.Count == 0 ? null : list[Next(0, list.Count - 1)];
        }
    }
}
