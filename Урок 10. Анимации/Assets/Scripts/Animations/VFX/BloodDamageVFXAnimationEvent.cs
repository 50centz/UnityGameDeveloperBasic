using System;
using UnityEngine;

namespace Animations.VFX
{
    public sealed class BloodDamageVFXAnimationEvent : MonoBehaviour
    {
        private const string DAMAGE_EVENT = "damage_event";

        [SerializeField] private AnimationEventListener animationEventListener;
        /*
         *  В рамках данного ДЗ никакие VFX не назначаются и не используются,
         *  но должен быть реализовано вывод в консоль сообщение типа:
         *  "[BloodDamageVFXAnimationEvent]: PlayBloodVFX()",
         *   когда происходит получения урона
         *   Скрипт должен быть на соответствующем объекте в персонаже
         */


        private void OnEnable()
        {
            animationEventListener.OnMessageReceived += PlayBloodVFX;
        }

        private void OnDisable()
        {
            animationEventListener.OnMessageReceived -= PlayBloodVFX;
        }

        private void PlayBloodVFX(string message)
        {
            if (message.Equals(DAMAGE_EVENT))
            {
                Debug.Log("[BloodDamageVFXAnimationEvent]: PlayBloodVFX()");
            }
            
        }
    }
}