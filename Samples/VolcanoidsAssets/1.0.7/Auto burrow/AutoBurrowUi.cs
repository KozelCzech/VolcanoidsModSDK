using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class AutoBurrowUi : MonoBehaviour
{
    [SerializeField]
    private CoreStatsUi m_coreUi;

    [SerializeField]
    private Transform m_toggleToClone;

    Toggle m_toggle;

    public bool IsStateEnabled
    {
        get { return m_coreUi.Runtime.TryGetComponent(out AutoBurrowState state) ? state.enabled : false; }
        set { if (m_coreUi.Runtime != null) m_coreUi.Runtime.gameObject.GetOrAddComponent<AutoBurrowState>().enabled = value; }
    }

    void Awake()
    {
        // Called when prefab is instantiated
        Debug.Log("AutoBurrowUiMod: modifying inventory screen instance " + transform.GetPath());

        Transform autoButtowToggleContainer = Instantiate(m_toggleToClone, m_toggleToClone.parent);
        autoButtowToggleContainer.SetAsFirstSibling();
        var localizedText = autoButtowToggleContainer.GetComponentInChildren<LocalizedUiText>();
        var text = localizedText.Text;
        Destroy(localizedText);
        text.text = "Auto Burrow";
        m_toggle = autoButtowToggleContainer.GetComponentInChildren<Toggle>();
        m_toggle.onValueChanged.AddListener(OnValueChanged);
    }

    void OnEnable()
    {
        m_toggle.isOn = IsStateEnabled;
    }

    public static void InitPrefab(CoreStatsUi ui, Transform toggleToClone)
    {
        Debug.Log("AutoBurrowUiMod: modifying inventory screen prefab");
        var uiComp = ui.gameObject.AddComponent<AutoBurrowUi>();
        uiComp.m_coreUi = ui;
        uiComp.m_toggleToClone = toggleToClone;
    }

    private void OnValueChanged(bool arg0)
    {
        if (isActiveAndEnabled)
        {
            IsStateEnabled = arg0;
        }
    }
}
