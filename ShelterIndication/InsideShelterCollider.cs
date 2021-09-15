using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideShelterCollider : MonoBehaviour
{
    
    public GameObject child;

    [SerializeField]
    private GameObject player;

    
    
    void Update()
    {
        if(player == null)
        {
            var script = GameObject.FindObjectOfType<Player>();
            player = script.gameObject;
            
        }
        
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
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name == "ShelterCollider")
    //    {
    //        isSafe = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.name == "ShelterCollider")
    //    {
    //        isSafe = false;
    //    }
    //}
}
