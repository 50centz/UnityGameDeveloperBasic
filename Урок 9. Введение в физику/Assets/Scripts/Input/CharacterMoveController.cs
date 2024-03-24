using System;
using UnityEngine;

namespace Homework
{
    public sealed class CharacterMoveController : MonoBehaviour
    {
        
        [SerializeField]
        private GameObject _character;

        private MoveComponent _moveComponent;
 
        private void Awake()
        {
            if ( !_character)
                throw new NotImplementedException($"[CharacterMoveController] : _character not set");

            _moveComponent = _character.GetComponent<MoveComponent>();
            if (!_moveComponent)
                throw new NotImplementedException($"[CharacterMoveController] : MoveComponent isNULL");
        }

        private void Update()
        {
            //TODO: Реализовать перемещение и поворот в нужную сторону с помощью нажатия WASD / Стрелочек на клавиатуре
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");
            Vector3 vectorMove = new Vector3(x, 0, z);
            _moveComponent.MoveDirection = vectorMove;
        }
    }
}