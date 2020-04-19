using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject BrainlyWin;
    public GameObject BeefyWin;
    public GameObject HotWin;
    public GameObject LongNeckWin;
    public GameObject Lose;

    public void Reset()
    {
        Canvas.SetActive(false);
        BrainlyWin.SetActive(false);
        BeefyWin.SetActive(false);
        HotWin.SetActive(false);
        LongNeckWin.SetActive(false);
        Lose.SetActive(false);
    }
}
