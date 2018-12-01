using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public List<StatBar> statBars;
    public List<GameObject> activityButtons;

    public void DeactivateAllStatBars()
    {
        foreach(StatBar statBar in statBars)
        {
            statBar.SetActive(false);
        }
    }

    public void DeactivateAllButtons()
    {
        foreach (GameObject button in activityButtons)
        {
            button.SetActive(false);
        }
    }

    public void ActivateStat(Stat stat, bool active)
    {
        GetStatBarByStat(stat).SetActive(active);

        if(stat != Stat.Time)
        {
            GetButtonByStat(stat).SetActive(active);
        }        
    }

    public StatBar GetStatBarByStat(Stat stat)
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

    public GameObject GetButtonByStat(Stat stat)
    {
        int id = stat.GetHashCode();

        if (activityButtons != null && activityButtons.Count > id)
        {
            return activityButtons[id];
        }
        else
        {
            return null;
        }
    }
}
