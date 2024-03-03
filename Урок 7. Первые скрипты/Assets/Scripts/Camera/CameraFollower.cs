using UnityEngine;

namespace Sample
{
    public sealed class CameraFollower : MonoBehaviour
    {
        
        public Vector3 offset;
        public Transform target;
       
       


        private void LateUpdate()
        {
            //Реализовать преследование камеры за персонажем с указанным offset и плавностью перемещения smoothTime.
            //Для плавности использовать Mathf.SmoothDamp() / Vector3.SmoothDamp();

            transform.position = target.position + offset;

        }
    }
}