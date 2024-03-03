using UnityEngine;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        private float _speed = 50f;
        private Vector3 _position;

        private void Update()
        {
            //TODO:
            //Реализовать перемещение и поворот в нужную сторону с помощью нажатия WASD или стрелочек на клавиатуре

            _position = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            transform.position += _position * Time.deltaTime * _speed;

        }
    }
}