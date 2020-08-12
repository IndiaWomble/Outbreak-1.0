using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Outbreak.VFX;

public class CollisionTest : MonoBehaviour
{
    private int numberOfHits = 0;
    private bool isHitting = false;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
            isHitting = true;
        if (Input.GetMouseButtonUp(0))
            isHitting = false;
        if (numberOfHits == 3)
        {
            Outbreak.Sound.SoundManager.Instance.PlaySoundEffectDelay(Outbreak.Sound.SoundEffect.Sowrd, 0.5f);

            Destroy(gameObject);

            VFXManager.Instance.CreateVFX(VFX.EnemyDamage, this.transform.position, this.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player_Sword" && isHitting)
        {

            this.GetComponent<EnemyAnimController>().PlayStagger();

            numberOfHits++;
        }
    }
}
