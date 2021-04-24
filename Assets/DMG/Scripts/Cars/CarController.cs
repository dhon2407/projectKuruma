using DMG.Cars.Wheels;
using DMG.UI.HUD;
using UnityEngine;

namespace DMG.Cars
{
    public class CarController : MonoBehaviour
    {
        [SerializeField]
        private float maxTorque;
        [SerializeField]
        private float maxSteerAngle;

        [SerializeField]
        private float turnSpeed;

        [SerializeField]
        private float acceleration;

        public float Speed
        {
            get => _speed;
            private set
            {
                _speed = value;
                if (_speedometer.CurrentSpeed != (int)_speed)
                    _speedometer.SetSpeed((int)_speed);
            }
        }
     
        private Rigidbody _rigidbody;
        private Speedometer _speedometer;
        private WheelDriver _wheelDriver;
        private PowerIndicator _powerMeter;

        private float _speed;
        private float _targetTorque;
        private float _targetSteerAngle;
        private float _steerDampVelocity;
        private float _torqueDampVelocity;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _wheelDriver = GetComponent<WheelDriver>();
            _speedometer = FindObjectOfType<Speedometer>();
            _powerMeter = FindObjectOfType<PowerIndicator>();
        }

        private void Update()
        {
            CheckInputs();
            UpdateCarParameters();
        }

        private void CheckInputs()
        {
            _targetTorque = Mathf.Clamp(_targetTorque + Input.GetAxisRaw("Vertical") * acceleration * Time.deltaTime, -maxTorque, maxTorque);
            _targetSteerAngle = Mathf.Clamp(_targetSteerAngle + Input.GetAxisRaw("Horizontal") * turnSpeed * Time.deltaTime, -maxSteerAngle, maxSteerAngle);
        }

        private void UpdateCarParameters()
        {
            Speed = _rigidbody.velocity.magnitude;
            _wheelDriver.SetTorque(_targetTorque);
            _wheelDriver.SetSteerAngle(_targetSteerAngle);

            if (!Input.GetButton("Vertical"))
                _targetTorque = Mathf.SmoothDamp(_targetTorque, 0, ref _torqueDampVelocity, 0.3f);
            if (!Input.GetButton("Horizontal"))
                _targetSteerAngle = Mathf.SmoothDamp(_targetSteerAngle, 0, ref _steerDampVelocity, 0.3f);

            _powerMeter.SetPowerRate(_targetTorque / maxTorque);
        }
    }
}
