using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Mods/EruptionTimerInPaintScreen")]
public class SetAsChild : MonoBehaviour
{
    GameObject parentofparent = null;
    Transform parent = null;
    
    public GameObject child;
    private void Update()
    {
        if(parentofparent == null)
        {
            child.SetActive(false);
            parentofparent = GameObject.Find("PaintCamera(Clone)");
            

        }
        else
        {
            parent = parentofparent.transform.GetChild(1);
            this.transform.SetParent(parent);
            child.SetActive(true);
            
        }
        
        
    }
    



}
