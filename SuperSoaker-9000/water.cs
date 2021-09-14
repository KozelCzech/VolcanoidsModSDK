using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public Weapon weapon;
    public WeaponReloader reloader;
    public ParticleSystem waterP;

    public AudioSource waterSound;
    public CapsuleCollider capCollider;

    private GameObject hitCog;
    private RagdollBlender ragdoll;

    void Update()
    {
        if (weapon != null && reloader != null && waterSound != null)
        {
            if (!reloader.IsReloading && reloader.LoadedAmmoAmount > 0)
            {
                if (weapon.IsFiring != true)
                {
                    waterP.Stop();

                    waterSound.Stop();
                }
                else
                {
                    if (!waterSound.isPlaying)
                    {
                        waterSound.Play();
                    }

                    waterP.Play();
                }
            }
            else
            {
                waterSound.Stop();
                waterP.Stop();
            }

        }



    }
    private void OnParticleCollision(GameObject other)
    {
        if (weapon.IsFiring && capCollider != null)
        {
            if (other.tag == "Exposed")
            {
                Debug.Log(other + " THE COG WAS HIT");
                hitCog = other;
                if (hitCog != null)
                {
                    ragdoll = hitCog.GetComponent<RagdollBlender>();
                    if (ragdoll != null)
                    {
                        ragdoll.StartStagger();
                    }
                }
                hitCog = null;
            }
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (weapon.IsFiring && capCollider != null)
    //    {
    //        if (other.gameObject.tag == "Exposed")
    //        {
    //            Debug.Log(other + " THE COG WAS HIT");
    //            hitCog = other.gameObject;
    //            if(hitCog != null)
    //            {
    //                ragdoll = hitCog.GetComponent<RagdollBlender>();
    //                if(ragdoll != null)
    //                {
    //                    ragdoll.StartStagger();
    //                }
    //            }
    //            hitCog = null;
    //        }
    //    }
    //}
}
