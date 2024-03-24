using System;
using UnityEngine;

namespace Homework
{
    public sealed class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject prefabBullet;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Transform bulletsContainer;
        public int Charges
        {
            get => this.charges;
            set => this.charges = value;
        }
        public int MaxCharges
        {
            get => this.maxCharges;
            set => this.maxCharges = value;
        }
        
        [SerializeField]
        private int maxCharges;
        
        [SerializeField]
        private int charges;

        public void Fire()
        {
            //TODO: Реализовать стрельбу пулями (prefab Bullet) через метод Instantiate() при наличии зарядов,
            //а также учет оставшихся зарядов после выстрела
            //в качестве оружие рассматривать GameObject <Visual> prefab Weapon
            if (charges > 0) 
            {
                GameObject bullet = Instantiate(prefabBullet, spawnPoint.position, spawnPoint.rotation, bulletsContainer);
                bullet.GetComponent<MoveComponent>().MoveDirection = spawnPoint.forward;
                charges--;  
            }
        }
        
        public void RestoreCharges(int numCharges)
        {
            //TODO: Реализовать пополнения зарядов, макс. количество зарядов равно MaxCharges.

            charges += numCharges;
            if (charges > maxCharges)
            {
                charges = maxCharges;
            }
        }
    }
}

