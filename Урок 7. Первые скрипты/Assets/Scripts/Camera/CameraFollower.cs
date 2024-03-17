using UnityEngine;

namespace Sample
{
    public sealed class CameraFollower : MonoBehaviour
    {

        [SerializeField] private Transform _transformCharacter;
        [SerializeField] private Vector3 _offset;
        private float _smoothTime;
        private Vector3 _velocity = Vector3.zero;
        private Vector3 _cameraPostition;
        float yVelocity = 0.0f;


        private void Start()
        {

        }
        private void LateUpdate()
        {
            //Реализовать преследование камеры за персонажем с указанным offset и плавностью перемещения smoothTime.
            //Для плавности использовать Mathf.SmoothDamp() / Vector3.SmoothDamp();

            _smoothTime = Mathf.SmoothDamp(transform.position.y, _transformCharacter.position.y + _offset.y, ref yVelocity, 0.1f);

            _cameraPostition = Vector3.SmoothDamp(transform.position, _transformCharacter.position + _offset, ref _velocity, _smoothTime);
            transform.position = _cameraPostition;

        }
    }
}