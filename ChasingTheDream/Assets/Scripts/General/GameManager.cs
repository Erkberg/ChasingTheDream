using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UIManager uiManager;

    private List<Stat> statsUnlocked = new List<Stat>();

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            Init();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        uiManager.DeactivateAllStatBars();

        UnlockStat(Stat.Dream);
        UnlockStat(Stat.Time);
        UnlockStat(Stat.Health);
        UnlockStat(Stat.Money);
    }

    private void UnlockStat(Stat stat)
    {
        statsUnlocked.Add(stat);
        uiManager.ActivateStat(stat, true);
    }

    private void RemoveStat(Stat stat)
    {
        if(statsUnlocked.Contains(stat))
        {
            statsUnlocked.Remove(stat);
            uiManager.ActivateStat(stat, false);
        }
    }
}
