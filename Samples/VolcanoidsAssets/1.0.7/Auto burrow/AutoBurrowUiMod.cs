using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Mods/AutoBurrowUiMod")]
public class AutoBurrowUiMod : GameCallbackAsset
{
    public CoreStatsUi UiRoot;
    public Transform ToggleToClone;

    static AutoBurrowUiMod()
    {
        // AutoBurrowState is added dynamically, register it as dynamic component so it's loaded properly (added during load when DataAutoBurrow is encountered)
        PersistentContext.RegisterDynamicComponent<DataAutoBurrow, AutoBurrowState>();
    }

    protected override void OnDataLoaded()
    {
        AutoBurrowUi.InitPrefab(UiRoot, ToggleToClone);
    }
}
