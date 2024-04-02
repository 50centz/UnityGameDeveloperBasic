using System;
using Components;
using UnityEngine;

namespace Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField]
        private GameObject character;

        private MoveComponent _moveComponent;
        
        private void Start()
        {
            _moveComponent = character.GetComponent<MoveComponent>();
            if (!_moveComponent) throw new NotImplementedException("[MoveController]: Absent MoveComponent");
        }

        private void Update()
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKey(KeyCode.A))
            {
                direction.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direction.x = 1;
            }

            if (Input.GetKey(KeyCode.W))
            {
                direction.z = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                direction.z = -1;
            }

            _moveComponent.MoveDirection = direction;
        }
    }
}