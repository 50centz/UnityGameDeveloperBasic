using UnityEngine;

namespace Sample
{
    public sealed class Сharacter : MonoBehaviour
    {
        [SerializeField] private HealthComponent _healthComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;

        private void FixedUpdate()
        {
            //TODO:
            //Реализовать вращение персонажа в том же направлении, куда и двигается


            // Это задание не совсем понял что нужно сделать )) это чтоб он вращался как юла ?? 

            //TODO:
            //Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят 

            /**

            if (_healthComponent.Health <= 0)
            {
                _moveComponent.enabled = false;
                _rotationComponent.enabled = false;
            }
            if (_healthComponent.Health > 0)
            {
                _moveComponent.enabled = true;
                _rotationComponent.enabled = true;
            }

            Когда включаю этот кусок кода, то тесты не проходят )) 
            */

        }
    }
}