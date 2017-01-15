namespace Assets.Scripts.GameBase.Interfaces.Entities.Body
{
    public interface IHummanBody : IBody
    {
        /// <summary>
        /// Entity legs
        /// </summary>
        ILegs Legs { get; }

        /// <summary>
        /// Enity upper body
        /// </summary>
        IUpperBody UpperBody { get; }
    }
}
