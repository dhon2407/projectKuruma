using UnityEngine;

namespace DMG.Weapon
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private bool _fired;
        private Vector3 _direction;

        public void Fire(Vector3 direction)
        {
            _direction = direction;
            _fired = true;
        }

        private void Update()
        {
            if (_fired)
                transform.Translate(_direction.normalized * (speed * Time.deltaTime));
        }
    }
}