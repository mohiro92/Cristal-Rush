using System;

namespace Assets.Scripts.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ParameterNameAttribute : Attribute
    {
        public string Name { get; private set; }

        public ParameterNameAttribute(string name)
        {
            Name = name;
        }
    }
}
