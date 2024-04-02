using System;
using UnityEngine;

namespace Components
{
    public sealed class WeaponComponent : MonoBehaviour
    {
        public event Action OnFire;
        
        [SerializeField]
        private Transform firePoint;

        [SerializeField]
        private GameObject bulletPrefab;
        
        [SerializeField]
        private bool canFire = true;

        [SerializeField]
        private float bulletForce = 10;

        public bool CanFire
        {
            get => canFire;
            set => canFire = value;
        }

        public void Fire()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Vector3 force = firePoint.forward * bulletForce;
            bullet.GetComponent<Rigidbody>().AddForce(force, ForceMode.VelocityChange);
           
            OnFire?.Invoke();
        }
    }
}