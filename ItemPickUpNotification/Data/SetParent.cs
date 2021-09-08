using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Mods/ItemPickUpNotification")]
public class SetParent : ModCallbackAsset
{
    [SerializeField]
    GameObject m_myPrefab;

    public override void Init()
    {
        base.Init();

        var parent = UnityEngine.Object.FindObjectsOfType<HudCanvas>().FirstOrDefault(s => s.name == "ScaledUI");
        Instantiate(m_myPrefab, parent.transform);
    }
}