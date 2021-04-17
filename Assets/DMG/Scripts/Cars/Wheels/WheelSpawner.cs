using System;
using UnityEngine;

namespace DMG.Cars.Wheels
{
    public class WheelSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject wheelPrefab = null;
        [SerializeField]
        private bool flipPosition;

        public void SpawnWheel()
        {
            if (!wheelPrefab)
                throw new Exception("No wheel prefab assigned, failed initializing wheel.");

            var wheel = Instantiate(wheelPrefab, transform, true);
            
            if (flipPosition)
                wheel.transform.GetChild(0).localRotation = Quaternion.Euler(0,180,0);
        }
    }
}
