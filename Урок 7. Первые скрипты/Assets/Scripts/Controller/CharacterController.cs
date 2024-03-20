using UnityEngine;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private MoveComponent _moveComponent;

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

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 vectorMove = new Vector3(x, 0, z);
            _moveComponent.MoveDirection = vectorMove;
        }
    }
}