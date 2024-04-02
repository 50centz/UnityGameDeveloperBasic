using Animations;
using UnityEngine;

namespace Components
{
    public class AttackComponent : MonoBehaviour
    {
        /*
         * AttackComponent реагирует на действия пользователя и запускате анимацию выстрела, в том случае если выстрел возможен
         * 
         */

        [SerializeField] private ShootAnimatorTrigger _trigger;

        [SerializeField] private WeaponComponent _weapon;

        public void Fire()
        {
            if (_weapon.CanFire)
            {
                _trigger.StartAnimationFire();
            }
        }
    }
}