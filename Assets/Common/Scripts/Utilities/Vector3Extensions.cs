using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class Vector3Extensions
    {
        public static bool IsZero(this Vector3 v)
        {
            return Mathf.Abs(v.x) < Consts.Eps 
                && Mathf.Abs(v.y) < Consts.Eps 
                && Mathf.Abs(v.z) < Consts.Eps;
        }
    }
}
