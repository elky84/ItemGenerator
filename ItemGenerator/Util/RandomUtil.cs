namespace ItemGenerator.Util
{
    public class RandomUtil
    {
        private readonly Random Random = new();

        public int Next(int max)
        {
            return Random.Next(max);
        }

        public int Next(int min, int max)
        {
            if (min == max)
                return min;

            return Random.Next(min, max);
        }

        public double Next(double max)
        {
            return Random.NextDouble() * max;
        }

        public double Next(double min, double max)
        {
            if (min == max)
                return min;

            return Random.NextDouble() * (max - min) + min;
        }


        public float Next(float max)
        {
            return (float)Random.NextDouble() * max;
        }

        public float Next(float min, float max)
        {
            if (min == max)
                return min;

            return (float)Random.NextDouble() * (max - min) + min;
        }

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public T Pick<T>(IList<T> list) where T : new()
        {
            if (list.Count == 0)
                return default!;

            return list[Next(0, list.Count - 1)];
        }
    }
}
