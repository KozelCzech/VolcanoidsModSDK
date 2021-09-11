using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FlameParticles : MonoBehaviour
{
    public Weapon weapon;
    public WeaponReloader reloader;
    public ParticleSystem flame;

    public AudioSource fireSound;

    
    
    void Update()
    {
        if(weapon != null && reloader != null && fireSound != null)
        {
            if(!reloader.IsReloading && reloader.LoadedAmmoAmount > 0)
            {
                if (weapon.IsFiring != true)
                {
                    flame.Stop();
                    
                    fireSound.Stop();
                }
                else
                {
                    if(!fireSound.isPlaying)
                    {
                        fireSound.Play();
                    }
                    
                    flame.Play();
                }
            }
            else
            {
                fireSound.Stop();
                flame.Stop();
            }
            
        }
        
        
    }

    
}
