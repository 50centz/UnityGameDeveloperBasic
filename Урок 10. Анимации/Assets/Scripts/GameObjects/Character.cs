using Components;
using UnityEngine;

namespace GameObjects
{
    public sealed class Character : MonoBehaviour
    {
        [SerializeField]
        private HealthComponent healthComponent;

        [SerializeField]
        private MoveComponent moveComponent;

        [SerializeField]
        private RotateComponent rotateComponent;

        [SerializeField]
        private WeaponComponent shootComponent;

        private void FixedUpdate()
        {
            UpdateRotation();
            UpdateAlive();
        }

        private void UpdateRotation()
        {
            /*
             * Персонаж должен поворачиваться в сторону движения
             */

            rotateComponent.RotationDirection = moveComponent.MoveDirection;
        }

        private void UpdateAlive()
        {
            /*
             * Если здоровье персонажа равно нулю, то персонаж умирает и не может больше двигаться, поварачиваться и стрелять
             */

            if (healthComponent.Health <= 0)
            {
                moveComponent.enabled = false;
                rotateComponent.enabled = false;
                shootComponent.enabled = false;
            }
        }
    }
}