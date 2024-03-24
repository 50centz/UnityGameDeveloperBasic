using UnityEngine;

namespace Homework
{
    public sealed class Bullet : MonoBehaviour
    {
        public int Damage
        {
            get => this.damage;
            set => this.damage = value;
        }

        [SerializeField]
        private int damage;
        
        private void OnTriggerEnter(Collider other)
        {
            //TODO: Реализовать нанесение урона цели при попадание пули в Character.
            //После нанесения урона пуля уничтожается
            if (other.TryGetComponent(out HealthComponent healthComponent))
            {
                healthComponent.TakeDamage(damage);
                Destroy(this.gameObject);
            }
        }
    }
}