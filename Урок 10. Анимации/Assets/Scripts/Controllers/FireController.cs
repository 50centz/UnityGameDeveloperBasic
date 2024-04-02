using System;
using Components;
using UnityEngine;

namespace Controllers
{
    public sealed class FireController : MonoBehaviour
    {
        /*
         *  реализовать выстрел через AttackComponent
         */

        [SerializeField]
        private GameObject character;

        private AttackComponent _attackComponent;

        private void Start()
        {
            _attackComponent = character.GetComponent<AttackComponent>();
            if (!_attackComponent) throw new NotImplementedException("[FireController]: Absent AttackComponent");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _attackComponent.Fire();
            }
        }
    }
}