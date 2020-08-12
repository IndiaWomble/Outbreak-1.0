using UnityEngine;

namespace Outbreak.VFX
{
    public enum VFX
    {
        Damage,
        Fire,
        Heal,
        EnemyDamage
    };

    public class VFXManager : SingletonBehaviour<VFXManager>
    {
        public GameObject[] VFX;

        public void CreateVFX(VFX effect, Vector3 position, Quaternion rotation)
        {
            GameObject vfxObject = Instantiate(VFX[(int)effect], position, rotation);
            vfxObject.SetActive(true);
            ParticleSystem particleSystem = vfxObject.GetComponent<ParticleSystem>();
            particleSystem.Play();
        }
    }
}