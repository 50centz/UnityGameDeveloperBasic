using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class DeathAnimatorTrigger : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;

        /*
         * Должен управлять анимационным событием смерти
         */


        private Animator _animator;

        private static int death = Animator.StringToHash("Death");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            healthComponent.OnDeath += StartAnimationDeath;
        }

        private void OnDisable()
        {
            healthComponent.OnDeath -= StartAnimationDeath;
        }

        public void StartAnimationDeath()
        {
            _animator.SetTrigger(death);
        }
    }
}