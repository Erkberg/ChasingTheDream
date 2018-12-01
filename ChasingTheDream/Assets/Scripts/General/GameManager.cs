using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public const float maxBarFillAmount = 100f;
    private const float statFillUpRate = 1f;
    private const float statDeclineRate = 0.2f;

    public UIManager uiManager;
    public Stat currentActivity;

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
        UnlockStat(Stat.Fun);

        //UnlockStat(Stat.Social);
        //UnlockStat(Stat.Love);
        //UnlockStat(Stat.Family);
    }

    private void Update()
    {
        AdjustStats();
    }

    private void AdjustStats()
    {
        foreach(StatBar statBar in uiManager.statBars)
        {
            if(statBar.isActive)
            {
                if(statBar.stat != Stat.Dream && statBar.stat != Stat.Time)
                {
                    statBar.SubtractFillAmount(statDeclineRate * Time.deltaTime);
                }

                if(statBar.stat == Stat.Time)
                {
                    statBar.AddFillAmount(statFillUpRate * Time.deltaTime);
                }

                if(statBar.stat == currentActivity)
                {
                    statBar.AddFillAmount(statFillUpRate * Time.deltaTime);
                }
            }
        }
    }

    public void OnStatBarEmpty(Stat stat)
    {

    }

    public void OnTimeBarFull()
    {

    }

    public void SetCurrentActivity(int statID)
    {
        currentActivity = GetStatByID(statID);
    }

    public Stat GetStatByID(int id)
    {
        foreach(StatBar statBar in uiManager.statBars)
        {
            if(statBar.stat.GetHashCode() == id)
            {
                return statBar.stat;
            }
        }

        return Stat.Dream;
    }

    private void UnlockStat(Stat stat)
    {
        statsUnlocked.Add(stat);
        uiManager.ActivateStat(stat, true);

        if (stat != Stat.Dream && stat != Stat.Time)
        {
            uiManager.GetStatBarByStat(stat).SetFillAmount(maxBarFillAmount / 2f);
        }
        
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
