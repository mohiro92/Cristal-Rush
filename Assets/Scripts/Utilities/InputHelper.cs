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
            return id > 0 ? string.Format("{0}{1}", prefix, id) : prefix;
        }

        public static IList<string> AxesPrefixes
        {
            get
            {
                return new List<string>
                {
                    Consts.HorizontalPrefixStr,
                    Consts.VerticalPrefixStr,
                    Consts.HorizontalRightPrefixStr,
                    Consts.VerticalRightPrefixStr
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

            IsActive(Consts.KeyBoardId, result);

            for (int i = 1; i <= NumberOfJoisticks; i++)
            {
                IsActive(i, result);
            }

            return result;
        }

        private static void IsActive(int id, Dictionary<int, List<string>> dictionary)
        {
            foreach (var prefix in AxesPrefixes)
            {
                var axisName = GetAxisName(prefix, id);

                var axisVal = Input.GetAxis(axisName);

                if (Mathf.Abs(axisVal) > Consts.Eps)
                {
                    if (dictionary.ContainsKey(id))
                    {
                        dictionary[id].Add(prefix);
                    }
                    else
                    {
                        dictionary.Add(id, new List<string> { prefix });
                    }
                    break;
                }
            }

            foreach (var prefix in ButtonsPrefixes)
            {
                var axisName = GetAxisName(prefix, id);
                if (Input.GetButton(axisName))
                {
                    if (dictionary.ContainsKey(id))
                    {
                        dictionary[id].Add(prefix);
                    }
                    else
                    {
                        dictionary.Add(id, new List<string> { prefix });
                    }
                    break;
                }
            }
        }
    }
}
