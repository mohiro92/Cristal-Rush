namespace Assets.Scripts.GameBase.Interfaces.Entities.Body
{
    public interface IHumanBody : IEntityBody
    {
        /// <summary>
        /// Entity legs
        /// </summary>
        ILegs Legs { get; }

        /// <summary>
        /// Enity upper body
        /// </summary>
        ITorso Torso { get; }
    }
}
