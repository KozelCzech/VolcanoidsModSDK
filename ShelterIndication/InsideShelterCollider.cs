using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideShelterCollider : MonoBehaviour
{
    
    public GameObject child;

   
    
    void Update()
    {
        
        
        child.SetActive(Player.Local != null && IsInSafeZone(Player.Local.transform.position));
        
    }
    private bool IsInSafeZone(Vector3 position)
    {
        foreach (var zone in BlastWaveSafeZone.Instances)
        {
            if (zone.IsSafe(position))
            {
                
                return true;
                
            }
        }
        
        return false;
    }
    
}
