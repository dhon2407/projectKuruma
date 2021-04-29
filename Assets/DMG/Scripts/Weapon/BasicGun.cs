using UnityEngine;

namespace DMG.Weapon
{
    public class BasicGun : MonoBehaviour
    {
        [SerializeField]
        private Projectile bullet;

        [SerializeField]
        private Transform muzzle;

        public void Fire()
        {
            var p = Instantiate(bullet, muzzle.position, Quaternion.identity);
            p.Fire(muzzle.forward);
        }
    }
}