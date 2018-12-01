using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public GameObject holder;
    public Image fillBar;

    private bool isActive = false;

	public void SetActive(bool active)
    {
        isActive = active;
        holder.SetActive(active);
    }
}
