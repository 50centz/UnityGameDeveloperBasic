using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class ShootAnimatorTrigger : MonoBehaviour
    {

        /*
         * Должен управлять анимационным событием выстрела
         */



        private Animator _animator;

        private static int fire = Animator.StringToHash("Fire");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        public void StartAnimationFire()
        {
            _animator.SetTrigger(fire);
        }
    }
}