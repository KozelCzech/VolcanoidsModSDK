using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Mods/ItemPickUpNotification")]
public class SetParent : GameCallbackAsset
{
    [SerializeField]
    GameObject m_myPrefab;

    protected override void OnGameLoad()
    {
        base.OnGameLoad();

        var parent = UnityEngine.Object.FindObjectsOfType<HudCanvas>().FirstOrDefault(s => s.name == "ScaledUI");
        Instantiate(m_myPrefab, parent.transform);
    }
}