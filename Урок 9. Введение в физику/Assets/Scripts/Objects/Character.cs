using UnityEngine;

namespace Homework
{
    public sealed class Character : MonoBehaviour
    {
        private RotationComponent rotationComponent;
        private MoveComponent moveComponent;
        private HealthComponent healthComponent;

        private void Awake()
        {
            rotationComponent = GetComponent<RotationComponent>();
            moveComponent = GetComponent<MoveComponent>();
            healthComponent = GetComponent<HealthComponent>();
        }

        private void Update()
        {
            //TODO: Реализовать вращение персонажа в том же направлении, куда и двигается
            rotationComponent.RotationDirection = moveComponent.MoveDirection;
            
            //TODO:Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят

            if (healthComponent.Health == 0)
            {
                rotationComponent.enabled = false;
                moveComponent.enabled = false;
            }
        }
    }
}