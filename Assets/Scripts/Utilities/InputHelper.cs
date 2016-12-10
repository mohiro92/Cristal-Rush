using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class InputHelper
    {
        private static IList<string> _joisticksNames;

        public static IList<string> JoistickNamesList
        {
            get
            {
                if (_joisticksNames == null)
                {
                    _joisticksNames = Input.GetJoystickNames();
                }

                return _joisticksNames;
            }
        }

        public static int GetId(string joistickName)
        {
            int id = 0;
            for (; id < JoistickNamesList.Count; ++id)
            {
                if (JoistickNamesList[id] == joistickName)
                    return id;
            }

            throw new ArgumentException();
        }

        public static string GetJoistickName(int id)
        {
            return JoistickNamesList[id];
        }

        public static string GetAxisName(string prefix, int id)
        {
            return string.Format("{0}{1}", prefix, id);
        }

        public static IList<string> AxesPrefixes
        {
            get
            {
                return new List<string>
                {
                    Consts.HorizontalPrefixStr,
                    Consts.VerticalPrefixStr,
                };
            }
        }

        public static IList<string> ButtonsPrefixes
        {
            get
            {
                return new List<string>
                {
                    Consts.FirePrefixStr,
                    Consts.JumpPrefixStr,
                };
            }
        }

        public const int NumberOfJoisticks = 11;
        public static Dictionary<int, List<string>> GetActiveInputIds()
        {
            var result = new Dictionary<int, List<string>>();

            for (int i = 1; i <= NumberOfJoisticks; i++)
            {
                foreach (var prefix in AxesPrefixes)
                {
                    var axisName = GetAxisName(prefix, i);

                    var axisVal = Input.GetAxis(axisName);

                    if (Mathf.Abs(axisVal) > Consts.Eps)
                    {
                        if (result.ContainsKey(i))
                        {
                            result[i].Add(prefix);
                        }
                        else
                        {
                            result.Add(i, new List<string> {prefix});
                        }
                        break;
                    }
                }

                foreach (var prefix in ButtonsPrefixes)
                {
                    var axisName = GetAxisName(prefix, i);
                    if (Input.GetButton(axisName))
                    {
                        if (result.ContainsKey(i))
                        {
                            result[i].Add(prefix);
                        }
                        else
                        {
                            result.Add(i, new List<string> { prefix });
                        }
                        break;
                    }
                }
            }

            return result;
        }
    }
}
