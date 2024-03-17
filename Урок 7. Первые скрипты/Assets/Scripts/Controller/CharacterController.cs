using UnityEngine;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        private Vector3 vectorMove;

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotationComponent _rotationComponent;
        private float _rotationY;

        private void Awake()
        {
            Debug.Log($"[{_moveComponent}]");
            if (!_moveComponent)
            {
                throw new NotImplementedException($"[CharacterController:] {gameObject.name}");
            }

        }

        private void Update()
        {
            //TODO:
            //Реализовать перемещение и поворот в нужную сторону с помощью нажатия WASD или стрелочек на клавиатуре

            vectorMove = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _moveComponent.MoveDirection = vectorMove;
            _rotationComponent.RotationDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        }
    }
}