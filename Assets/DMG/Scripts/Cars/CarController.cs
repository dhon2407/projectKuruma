using DMG.UI.HUD;
using DMG.Weapon;
using UnityEngine;

namespace DMG.Cars
{
    public class CarController : VehicleController
    {
        [SerializeField]
        private BasicGun gun;

        
        public override float Speed
        {
            get => _speed;
            protected set
            {
                _speed = value;
                if (_speedometer.CurrentSpeed != (int)_speed)
                    _speedometer.SetSpeed((int)_speed);
            }
        }
        
        private Speedometer _speedometer;
        private PowerIndicator _powerMeter;

        protected override void Init()
        {
            base.Init();
            _speedometer = FindObjectOfType<Speedometer>();
            _powerMeter = FindObjectOfType<PowerIndicator>();
        }

        protected override void UpdateCarParameters()
        {
            base.UpdateCarParameters();
            _powerMeter.SetPowerRate(TargetTorque / maxTorque);
        }

        protected override void Update()
        {
            base.Update();
            if (Input.GetKeyDown(KeyCode.R))
                gun.Fire();
        }
    }
}
