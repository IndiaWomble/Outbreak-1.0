using UnityEngine;
using UnityEngine.UI;

namespace Outbreak.Player
{
    public class PlayerHealth : MonoBehaviour
    {
        private float currentHealth;
        public delegate void PlayerDied();
        public static event PlayerDied PlayerDiedEvent;

        public delegate void PlayerDamge(float damage);
        public static event PlayerDamge PlayerDamageEvent;

        void Awake ()
        {
            currentHealth = 5000;
        }

        void Update ()
        {
            if(currentHealth == 0)
            {
                Death();
            }
        }

        void Death ()
        {
            if (PlayerDiedEvent != null)
                PlayerDiedEvent();
            else
                Debug.LogError("ERR: PlayerDiedEvent not registered !");
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Enemy_Anim Variant(Clone)")
            {
                currentHealth--;

                if(PlayerDamageEvent != null)
                {
                    PlayerDamageEvent(currentHealth);
                }
            }
        }
    }
}