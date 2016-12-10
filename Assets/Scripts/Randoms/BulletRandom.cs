using System;

namespace Assets.Scripts.Randoms
{
    public static class BulletRandom
    {
        private static int? _seed = Guid.NewGuid().GetHashCode();
        private static Random _rand;

        public static Random Instance
        {
            get
            {
                if (_rand == null)
                {
                    _rand = _seed.HasValue ? new Random(_seed.Value) : new Random();
                }

                return _rand;
            }
        }

        public static int Seed
        {
            get { return _seed ?? default(int); }
            set
            {
                _seed = value;

                _rand = _seed.HasValue ? new Random(_seed.Value) : new Random();
            }
        }

        public static float NextFloat
        {
            get { return (float) _rand.NextDouble(); }
        }
    }
}
