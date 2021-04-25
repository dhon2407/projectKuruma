using UnityEngine;

namespace DMG.GameSystem.Inputs
{
    public class JustMovingForward : MonoBehaviour, IInputHandler
    {
        public float Throttle => 1;
        public float Steer => 0;
        public bool NoThrottle => false;
        public bool NoSteer => false;
        public float Brake => 0;
        public bool NoBrake => false;
    }
}