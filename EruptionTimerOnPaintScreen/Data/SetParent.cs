using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName = "Mods/EruptionTimerOnPaintScreen")]
public class SetParent : ModCallbackAsset
{
    [SerializeField]
    GameObject m_myPrefab;

    public override void OnGameLoaded(Scene gameScene)
    {
        base.OnGameLoaded(gameScene);
        var parent = UnityEngine.Object.FindObjectsOfType<HudCanvas>().FirstOrDefault(s => s.name == "ScaledUI");
        Instantiate(m_myPrefab, parent.transform);
    }

}
