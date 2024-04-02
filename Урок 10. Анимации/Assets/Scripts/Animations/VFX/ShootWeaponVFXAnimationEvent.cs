using Components;
using UnityEngine;

namespace Animations.VFX
{
    public sealed class ShootWeaponVFXAnimationEvent : MonoBehaviour
    {
        [SerializeField] private WeaponComponent _weaponComponent;

        /*
         *  В рамках данного ДЗ никакие VFX не назначаются и не используются,
         *  но должен быть реализовано вывод в консоль сообщение типа:
         *  "[ShootWeaponVFXAnimationEvent]: ShootVFX()",
         *   когда происходит выстрел (для отображения вспышки выстрела)
         *  Скрипт должен быть на соответствующем объекте в оружие
         */

        private void OnEnable()
        {
            _weaponComponent.OnFire += PlayShootVFX;
        }


        private void OnDisable()
        {
            _weaponComponent.OnFire -= PlayShootVFX;
        }

        private void PlayShootVFX()
        {
            Debug.Log("[ShootWeaponVFXAnimationEvent]: ShootVFX()");
        }
    }
}