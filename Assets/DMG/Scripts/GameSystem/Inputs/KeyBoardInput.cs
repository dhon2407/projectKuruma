using UnityEngine;

namespace DMG.GameSystem.Inputs
{
    public class KeyBoardInput : MonoBehaviour, IInputHandler
    {
        public float Throttle => Input.GetAxisRaw("Vertical");
        public float Steer => Input.GetAxisRaw("Horizontal");
        public bool NoThrottle => !Input.GetButton("Vertical");
        public bool NoSteer => !Input.GetButton("Horizontal");
        public float Brake => Input.GetKey(KeyCode.Space) ? 1 : 0;
        public bool NoBrake => !Input.GetKey(KeyCode.Space);
    }
}