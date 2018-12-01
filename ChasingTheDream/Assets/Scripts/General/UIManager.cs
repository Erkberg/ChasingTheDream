using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<StatBar> statBars;

    public void DeactivateAllStatBars()
    {
        foreach(StatBar statBar in statBars)
        {
            statBar.SetActive(false);
        }
    }

    public void ActivateStat(Stat stat, bool active)
    {
        GetStatBarByStat(stat).SetActive(active);
    }

    private StatBar GetStatBarByStat(Stat stat)
    {
        int id = stat.GetHashCode();

        if(statBars != null && statBars.Count > id)
        {
            return statBars[id];
        }
        else
        {
            return null;
        }
    }
}
