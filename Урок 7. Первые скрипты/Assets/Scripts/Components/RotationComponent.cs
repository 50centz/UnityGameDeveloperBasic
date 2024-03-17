using UnityEngine;

namespace Sample
{
    public sealed class RotationComponent : MonoBehaviour
    {
        private float _step;
        public float RotationSpeed
        {
            get => this.rotationSpeed;
            set => this.rotationSpeed = value;
        }

        public Vector3 RotationDirection
        {
            get => this.rotationDirection;
            set => this.rotationDirection = value;
        }

        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private Vector3 rotationDirection;

        private void Update()
        {
            //TODO: Реализовать покадровый поворот через transform с помощью методов
            //Quaternion.RotateTowards, Quaternion.LookRotation и
            //параметров rotationSpeed, rotationDirection и Time.deltaTime;
            //если направление перемещения ноль, когда не нажата ни одна из клавиш (WASD),
            //то поворот происходить не должен

            if (rotationDirection == Vector3.zero)
            {
                return;
            }

            _step = rotationSpeed * Time.deltaTime;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(rotationDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, _step);

        }
    }
}