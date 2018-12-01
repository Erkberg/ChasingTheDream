using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Stat stat;
    public GameObject holder;
    public Image fillBar;
    public bool isActive = false;

    private float currentAmount = 0f;

	public void SetActive(bool active)
    {
        isActive = active;
        holder.SetActive(active);
    }

    public void SetFillAmount(float amount)
    {
        currentAmount = amount;
        AdjustFillbarUI();
    }

    public void AddFillAmount(float amount)
    {
        currentAmount += amount;

        if(currentAmount >= GameManager.maxBarFillAmount)
        {
            currentAmount = GameManager.maxBarFillAmount;
        }

        AdjustFillbarUI();
    }

    public void SubtractFillAmount(float amount)
    {
        currentAmount -= amount;

        if (currentAmount <= 0f)
        {
            currentAmount = 0f;
            GameManager.instance.OnStatBarEmpty(stat);
        }

        AdjustFillbarUI();
    }

    private void AdjustFillbarUI()
    {
        fillBar.fillAmount = currentAmount / GameManager.maxBarFillAmount;
    }
}
