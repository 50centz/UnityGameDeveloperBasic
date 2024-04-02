using Components;
using UnityEngine;

namespace Animations
{
    [RequireComponent(typeof(Animator))]
    public sealed class MoveAnimatorController : MonoBehaviour
    {
        /*
        * Должен управлять анимацией перемещения
        */

        [SerializeField] private MoveComponent moveComponent;

        private Animator _animator;

        private static int isMovingHash = Animator.StringToHash("isMoving");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        private void Update()
        {
            _animator.SetBool(isMovingHash, moveComponent.IsMoving);
        }
    }
}