using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideShelterCollider : MonoBehaviour
{
    public bool isSafe;
    public GameObject child;

    [SerializeField]
    private GameObject player;
    [SerializeField]
    private CapsuleCollider playerCollider;

    
    void Update()
    {
        if(player == null)
        {
            var script = GameObject.FindObjectOfType<Player>();
            player = script.gameObject;
            playerCollider = player.GetComponentInChildren<CapsuleCollider>();
        }
        if(isSafe)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ShelterCollider")
        {
            isSafe = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "ShelterCollider")
        {
            isSafe = false;
        }
    }
}
