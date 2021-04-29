using DMG.Cars.Wheels;
using DMG.GameSystem.Inputs;
using UnityEngine;

namespace DMG.Cars
{
    public abstract class VehicleController : MonoBehaviour
    {
        [SerializeField]
        protected float maxTorque;
        [SerializeField]
        private float maxSteerAngle;
        [SerializeField]
        private float maxBrakeTorque;
        [SerializeField]
        private float turnSpeed;
        [SerializeField]
        private float acceleration;
        [SerializeField]
        private float brakeResponse;
        
        public virtual float Speed
        {
            get => _speed;
            protected set => _speed = value;
        }
                
        protected float _speed;
        protected float TargetTorque;
        
        private IInputHandler _inputHandler;
        private Rigidbody _rigidbody;
        private WheelDriver _wheelDriver;
        private float _targetSteerAngle;
        private float _steerDampVelocity;
        private float _torqueDampVelocity;
        private float _targetBrakeTorque;

        private void Awake()
        {
            Init();
        }

        protected virtual void Init()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _wheelDriver = GetComponent<WheelDriver>();
            _inputHandler = GetComponentInChildren<IInputHandler>();
        }

        protected virtual void Update()
        {
            CheckInputs();
            UpdateCarParameters();
        }

        private void CheckInputs()
        {
            TargetTorque = Mathf.Clamp(TargetTorque + _inputHandler.Throttle * acceleration * Time.deltaTime, -maxTorque, maxTorque);
            _targetSteerAngle = Mathf.Clamp(_targetSteerAngle + _inputHandler.Steer * turnSpeed * Time.deltaTime, -maxSteerAngle, maxSteerAngle);
            _targetBrakeTorque = Mathf.Clamp(_targetBrakeTorque + _inputHandler.Brake * brakeResponse * Time.deltaTime, 0, maxBrakeTorque);
        }

        protected virtual void UpdateCarParameters()
        {
            Speed = _rigidbody.velocity.magnitude;
            _wheelDriver.SetTorque(TargetTorque);
            _wheelDriver.SetSteerAngle(_targetSteerAngle);
            _wheelDriver.SetBrakeTorque(_targetBrakeTorque);
            
            if (_inputHandler.NoThrottle)
                TargetTorque = Mathf.SmoothDamp(TargetTorque, 0, ref _torqueDampVelocity, 0.3f);
            if (_inputHandler.NoSteer)
                _targetSteerAngle = Mathf.SmoothDamp(_targetSteerAngle, 0, ref _steerDampVelocity, 0.3f);
            if (_inputHandler.NoBrake)
                _wheelDriver.SetBrakeTorque(0);
        }
    }
}