using System.Linq;
using System.Reflection;
using Assets.Scripts.Attributes;

namespace Assets.Scripts.Enums
{
    public static class EntityStateExtensions
    {
        public static string ParameterName(this EntityState state)
        {
            MemberInfo memberInfo =  state.GetType().GetMember(state.ToString()).FirstOrDefault();
            object[] attributes = memberInfo.GetCustomAttributes(typeof(ParameterNameAttribute), false);

            return ((ParameterNameAttribute) attributes[0]).Name;
        }
    }
}
