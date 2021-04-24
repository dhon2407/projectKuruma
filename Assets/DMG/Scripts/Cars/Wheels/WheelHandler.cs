using System;
using UnityEngine;

namespace DMG.Cars.Wheels
{
    public class WheelHandler : MonoBehaviour
    {
        [SerializeField]
        private GameObject wheelPrefab = null;
        [SerializeField]
        private float wheelScale = 1;
        [SerializeField]
        private float wheelOffset = 0;
        [SerializeField]
        private bool flipPosition;

        private GameObject _wheel;
        private Transform _wheelModel;
        private WheelCollider _wheelCollider;

        private void Awake()
        {
            _wheelCollider = GetComponent<WheelCollider>();
        }

        public void SpawnWheel()
        {
            if (!wheelPrefab)
                throw new Exception("No wheel prefab assigned, failed initializing wheel.");

            _wheel = Instantiate(wheelPrefab, transform, true);
            _wheel.transform.localScale *= wheelScale;
            _wheelModel = _wheel.transform.GetChild(0);
            
            if (flipPosition)
                _wheelModel.GetChild(0).localRotation = Quaternion.Euler(0,180,0);
        }

        private void Update()
        {
            UpdateWheelModelPosition();
        }

        private void UpdateWheelModelPosition()
        {
            if (!_wheel)
                return;
            
            _wheelCollider.GetWorldPose(out var position, out var rotation);
            _wheel.transform.position = position;

            if (!_wheelModel)
                return;
            
            var modelPosition = _wheelModel.localPosition;
            modelPosition.x = wheelOffset * (flipPosition ? 1 : -1);
            _wheelModel.localPosition = modelPosition;
            _wheelModel.rotation = rotation;
           //_wheelModel.RotateAround(_wheelModel.position, Vector3.up, flipPosition ? 180 : 0);
        }

        private void OnValidate()
        {
            if (_wheel)
                _wheel.transform.localScale *= wheelScale;
        }
    }
}
