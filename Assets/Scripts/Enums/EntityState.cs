using Assets.Scripts.Attributes;

namespace Assets.Scripts.Enums
{
    public enum EntityState
    {
        [ParameterName("Idle")]
        Idle,

        [ParameterName("MovingForward")]
        MovingForward,

        [ParameterName("MovingBackward")]
        MovingBackward,

        [ParameterName("MovingRight")]
        MovingRight,

        [ParameterName("MovingLeft")]
        MovingLeft,

        [ParameterName("Atack")]
        Atack,

        [ParameterName("Dead")]
        Dead,
    }
}
