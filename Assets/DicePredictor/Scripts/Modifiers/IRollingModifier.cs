public interface IRollingModifier : IDiceRoller
{
    public IDiceRoller TargetRoller { get; set; }
}