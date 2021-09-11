using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public Weapon weapon;
    public WeaponReloader reloader;
    public ParticleSystem waterP;

    public AudioSource waterSound;
    public BoxCollider BoxCollider;

    private GameObject hitCog;
    private Ragdoll ragdoll;

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
    private void OnTriggerEnter(Collider other)
    {
        if (weapon.IsFiring)
        {
            if (other.gameObject.tag == "Exposed")
            {
                Debug.Log(other + " THE COG WAS HIT");
                hitCog = other.gameObject;
                if(hitCog != null)
                {
                    ragdoll = hitCog.GetComponent<Ragdoll>();
                    foreach (var element in ragdoll.Elements)
                    {
                        if (element != null && element.Joint != null)
                        {
                            ragdoll.BreakJoint(element.Joint);
                        }
                    }
                }
                hitCog = null;
            }
        }
    }
}
