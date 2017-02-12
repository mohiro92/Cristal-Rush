using Assets.Scripts.Attributes;

namespace Assets.Scripts.Enums
{
    public enum EntityState
    {
        [ParameterName("Idle")]
        Idle,

        [ParameterName("Running")]
        Moving,
        
        [ParameterName("Atack")]
        Atack,

        [ParameterName("Dead")]
        Dead,
    }
}
