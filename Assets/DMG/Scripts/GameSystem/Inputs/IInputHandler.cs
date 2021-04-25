namespace DMG.GameSystem.Inputs
{
    public interface IInputHandler
    {
        float Throttle { get; }
        float Steer { get; }
        bool NoThrottle { get; }
        bool NoSteer { get; }
        float Brake { get; }
        bool NoBrake { get; }
    }
}