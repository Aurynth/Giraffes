using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsBar : MonoBehaviour
{
    public Slider Stat;

    public void setMaxStat(int maxStat)
    {
        Stat.maxValue = 100;
    }

    public void SetStat(int StatVal)
    {
        Stat.value = StatVal;
    }
}
