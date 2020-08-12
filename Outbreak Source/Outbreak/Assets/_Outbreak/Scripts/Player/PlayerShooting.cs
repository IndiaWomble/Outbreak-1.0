using UnityEngine;

namespace Outbreak.Player
{
    public class PlayerShooting : MonoBehaviour
    {
        public int damagePerShot = 100;
        public float timeBetweenBullets = 0.15f;
        public float coolDownTime = 14f;
        public float range = 100f;

        float timer;
        float cooler = 0;
        Ray shootRay = new Ray();
        RaycastHit shootHit;
        int shootableMask;
        ParticleSystem gunParticles;
        AudioSource gunAudio;
   
        float effectsDisplayTime = 0.2f;

        void Awake ()
        {
            shootableMask = LayerMask.GetMask ("Shootable");
            gunParticles = GetComponent<ParticleSystem> ();
            gunAudio = GetComponent<AudioSource> ();
        }

        void Update ()
        {
            timer += Time.deltaTime;
        
            if (cooler <= coolDownTime)
            {
                if (Input.GetButton ("Fire2") && timer >= timeBetweenBullets && Time.timeScale != 0)
                {
                    Shoot ();
                }
                cooler += Time.deltaTime;
            }
            else
            {
                cooler -= Time.deltaTime;
            }

        }

        void Shoot ()
        {
            timer = 0f;

            gunAudio.Play ();

            gunParticles.Stop ();
            gunParticles.Play ();

            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;

            if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                GameObject hitEnemy = shootHit.collider.GetComponent<GameObject>();

                if(hitEnemy.name != "BOSS")
                {
                    Outbreak.Enemy.EnemyHealth enemyHealth = shootHit.collider.GetComponent<Outbreak.Enemy.EnemyHealth>();
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }
                }
            }
       
        }
    }
}