using System;

namespace Assets.Scripts.Randoms
{
    public static class EnemyRandom
    {
        private static int _seed = DateTime.Now.Hour;
        private static Random _rand;

        public static Random Instance
        {
            get
            {
                if (_rand == null)
                {
                    _rand = new Random(Seed);
                }

                return _rand;
            }
        }

        public static int Seed
        {
            get
            {
                return _seed;
            }
            set
            {
                _seed = value;

                _rand = new Random(Seed);
            }
        }

        public static float NextFloat(float maxValue)
        {
            return (float)Instance.NextDouble() *  maxValue;
        }
    }
}
