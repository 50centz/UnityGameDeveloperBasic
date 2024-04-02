using UnityEngine;

namespace Utils
{
    public sealed class SetParentOnAwake : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        private void Awake()
        {
            transform.SetParent(parent, false);
        }
    }
}