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

        [SerializeField]
        private float verticalOffset;

        

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
            var position = player.position;
            _referencePosition.z = position.z + distance;
            _referencePosition.y = position.y + verticalOffset;
            _transform.position = _referencePosition;
        }
    }
}
