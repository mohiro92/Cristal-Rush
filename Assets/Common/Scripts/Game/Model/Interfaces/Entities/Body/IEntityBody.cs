namespace Assets.Scripts.GameBase.Interfaces.Entities.Body
{
    public interface IEntityBody : IMoveable
    {
        bool IsJumping { get; set; }

        void Jump(float strength);
    }
}
