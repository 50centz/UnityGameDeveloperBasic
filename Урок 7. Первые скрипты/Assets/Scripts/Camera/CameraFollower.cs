using UnityEngine;

namespace Sample
{
    public sealed class CameraFollower : MonoBehaviour
    {

        [SerializeField] private Transform _transformCharacter;
        [SerializeField] private Vector3 _offset;
        [SerializeField][Range(0, 2f)] private float _smoothTime;
        private Vector3 _velocity = Vector3.zero;


        private void LateUpdate()
        {
            //Реализовать преследование камеры за персонажем с указанным offset и плавностью перемещения smoothTime.
            //Для плавности использовать Mathf.SmoothDamp() / Vector3.SmoothDamp();

            Vector3 cameraPostition = Vector3.SmoothDamp(transform.position, _transformCharacter.position + _offset, ref _velocity, _smoothTime);
            transform.position = cameraPostition;
        }
    }
}