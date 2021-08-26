using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AutoBurrowState : MonoBehaviour, IPersistentBehaviour<DataAutoBurrow>
{
    private Train m_train;

    void Awake()
    {
        TryGetComponent(out m_train);
    }

    void Update()
    {
        if (Island.Current.TimeToEruption < 60 && m_train.State == TrainState.Deploy && m_train.HasFinished)
        {
            m_train.EmergencyExit();
        }
    }

    public void Save(DataAutoBurrow data)
    {
        data.AutoBurrow = enabled;
    }

    public void Load(DataAutoBurrow data)
    {
        enabled = data.AutoBurrow;
    }
}
