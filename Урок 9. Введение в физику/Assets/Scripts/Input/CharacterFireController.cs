using System;
using UnityEngine;

namespace Homework
{
    public sealed class CharacterFireController : MonoBehaviour
    {
        [SerializeField]
        private GameObject _character;
        private Weapon _weapon;

        private void Start()
        {


            if (!_character)
                throw new NotImplementedException($"[CharacterFireController][{gameObject.name}] : _character not set");

            _weapon = _character.GetComponentInChildren<Weapon>();

            if (!_weapon)
                throw new NotImplementedException($"[CharacterFireController] : Пушки нет isNULL");
        }

        private void Update()
        {
            //TODO: Реализовать выстрел пулей при нажатии Space на клавиатуре
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _weapon.Fire();
            }
        }
    }
}