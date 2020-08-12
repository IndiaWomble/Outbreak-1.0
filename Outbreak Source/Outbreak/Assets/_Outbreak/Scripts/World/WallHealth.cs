using Outbreak.VFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Outbreak.World
{
    public class WallHealth : MonoBehaviour
    {
        private float health = 10000;
        public delegate void WallDamage(float damage);
        public static event WallDamage WallDamageEvent;
        public static event WallDamage WallRepairEvent;
        public delegate void WallDestroy();
        public static event WallDestroy WallDestroyEvent;
       // private bool canRepair = false;
        private bool isRepairing = false;
        
        void Update()
        {
            if (health == 0)
            {
                if (WallDestroyEvent != null)
                    WallDestroyEvent();
                else
                    Debug.LogError("ERR: WallDestroyEvent not registered !");
            }
            if (Input.GetKey(KeyCode.Space))
                isRepairing = true;
            if (Input.GetKeyUp(KeyCode.Space))
                isRepairing = false;
            //if (health == 10000)
            //    canRepair = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Enemy_Anim Variant(Clone)")
            {
                VFXManager.Instance.CreateVFX(VFX.VFX.Damage, this.transform.position, this.transform.rotation);
            }
            if (other.name == "Player_Character 2" && isRepairing/* && canRepair*/)
            {
                VFXManager.Instance.CreateVFX(VFX.VFX.Heal, this.transform.position, this.transform.rotation);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.name == "Enemy_Anim Variant(Clone)")
            {
                health--;

                if (WallDamageEvent != null)
                    WallDamageEvent(health);
                else
                    Debug.LogError("ERR: WallDamageEvent not registered !");
            }
            if (other.name == "Player_Character 2" && isRepairing/* && canRepair*/)
            {
                health+=5;
                if (WallRepairEvent != null)
                {
                    WallRepairEvent(health);
                }
                else
                    Debug.LogError("ERR: WallRepairEvent not registered !");
            }
            Debug.LogError(health);
        }
    }
}