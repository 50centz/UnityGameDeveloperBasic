using UnityEngine;

namespace Animations.VFX
{
    public sealed class DeathVFXAnimationEvent : MonoBehaviour
    {
        private const string DEATH_EVENT = "death_event";

        [SerializeField] private AnimationEventListener animationEventListener;
        /*
         *  В рамках данного ДЗ никакие VFX не назначаются и не используются,
         *  но должен быть реализовано вывод в консоль сообщение типа:
         *  "[DeathVFXAnimationEvent]: PlayDeathVFX()",
         *   когда происходит получения урона
         *   Скрипт должен быть на соответствующем объекте в персонаже
         */



        private void OnEnable()
        {
            animationEventListener.OnMessageReceived += PlayDeathVFX;
        }

        private void OnDisable()
        {
            animationEventListener.OnMessageReceived -= PlayDeathVFX;
        }

        private void PlayDeathVFX(string message)
        {
            if (message.Equals(DEATH_EVENT))
            {
                Debug.Log("[BloodDamageVFXAnimationEvent]: PlayDeathVFX()");
            }

        }
    }
}