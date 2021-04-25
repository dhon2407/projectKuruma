using UnityEngine;

namespace DMG.Cars.Wheels
{
    public class WheelDriver : MonoBehaviour
    {
        private WheelCollider[] _wheels;

        private float _inputSteerAngle;
        private float _inputTorque;
        private float _inputBrakeTorque;

        public void SetSteerAngle(float angle)
        {
            _inputSteerAngle = angle;
        }

        public void SetTorque(float torque)
        {
            _inputTorque = torque;
        }
        
        public void SetBrakeTorque(float brakeTorque)
        {
            _inputBrakeTorque = brakeTorque;
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

                wheel.brakeTorque = _inputBrakeTorque;
            }
        }
    }
}