using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class TakeDamageAnimatorTrigger : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;

        /*
         * Должен управлять анимационным событием получения урона
         */

        private Animator _animator;

        private static int damage = Animator.StringToHash("Damage");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            healthComponent.OnTakeDamage += StartAnimationDamage;
        }

        private void OnDisable()
        {
            healthComponent.OnTakeDamage -= StartAnimationDamage;
        }

        public void StartAnimationDamage()
        {
            _animator.SetTrigger(damage);
        }
    }
}