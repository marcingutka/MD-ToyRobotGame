namespace TRG.Models.Enums
{
    public enum OrientationState
    {
        North = 1,
        East = 2,
        South = 3,
        West = 4,
    }

    public static class OrientationStateExtensions
    {
        public static string ToLongString(this OrientationState state) =>
            state switch
            {
                OrientationState.North => "NORTH",
                OrientationState.East => "EAST",
                OrientationState.South => "SOUTH",
                OrientationState.West => "WEST",
                _ => string.Empty,
            };        
    }
}
