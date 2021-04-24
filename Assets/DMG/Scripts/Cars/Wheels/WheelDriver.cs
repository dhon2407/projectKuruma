using UnityEngine;

namespace DMG.Cars.Wheels
{
    public class WheelDriver : MonoBehaviour
    {
        private WheelCollider[] _wheels;

        private float _inputSteerAngle;
        private float _inputTorque;

        public void SetSteerAngle(float angle)
        {
            _inputSteerAngle = angle;
        }

        public void SetTorque(float torque)
        {
            _inputTorque = torque;
        }
        
        public void Start()
        {
            _wheels = GetComponentsInChildren<WheelCollider>();

            foreach (var wheel in _wheels)
            {
                var spawner = wheel.GetComponent<WheelHandler>();
                spawner.SpawnWheel();
            }
        }

        public void Update()
        {
            foreach (var wheel in _wheels)
            {
                if (wheel.transform.localPosition.z > 0)
                    wheel.steerAngle = _inputSteerAngle;

                if (wheel.transform.localPosition.z < 0)
                    wheel.motorTorque = _inputTorque;
            }
        }
    }
}