using UnityEngine;

namespace Homework
{
    public sealed class LifetimeComponent : MonoBehaviour
    {
        public float Lifetime
        {
            get { return this.lifetime; }
            set { this.lifetime = value; }
        }
        /// <summary>
        /// Время жизни пули в секундах, если она никуда не попала
        /// </summary>
        [SerializeField]
        private float lifetime;

        private void Update()
        {
            //TODO: Реализовать механику самоуничтожения пули, если она никуда не попала

            if (lifetime > 0)
            {
                lifetime -= Time.deltaTime;
            }
            else
            {
                Destroy(this.gameObject);
            } 
        }
    }
}