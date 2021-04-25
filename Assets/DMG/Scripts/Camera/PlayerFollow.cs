using System;
using UnityEngine;

namespace DMG.Camera
{
    public class PlayerFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform cameraTarget;

        [SerializeField]
        private Transform lookTarget;

        [SerializeField]
        private float speed;

        [SerializeField]
        private Vector3 distance;

        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void FixedUpdate()
        {
            var dPos = cameraTarget.position + distance;
            var sPos = Vector3.Lerp(_transform.position, dPos, speed * Time.fixedDeltaTime);
            _transform.position = sPos;
            _transform.LookAt(lookTarget.position);
        }
    }
}
