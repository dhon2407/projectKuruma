using System;
using UnityEngine;

namespace DMG.Camera
{
    public class HorizonPoint : MonoBehaviour
    {
        [SerializeField]
        private Transform player;
        [SerializeField]
        private float distance;

        private Transform _transform;
        private Vector3 _referencePosition;

        private void Awake()
        {
            _transform = transform;
        }

        private void Start()
        {
            _referencePosition = player.position;
        }

        private void FixedUpdate()
        {
            _referencePosition.z = player.position.z + distance;
            _transform.position = _referencePosition;
        }
    }
}
