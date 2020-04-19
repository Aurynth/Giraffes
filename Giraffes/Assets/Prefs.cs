using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Date", 2020);
        PlayerPrefs.SetInt("Generation", 1);
        PlayerPrefs.SetInt("MalePopulation", 5);
        PlayerPrefs.SetInt("AverageBeefiness", 50);
        PlayerPrefs.SetInt("AverageSpeediness", 50);
        PlayerPrefs.SetInt("AverageChonk", 50);
        PlayerPrefs.SetInt("AverageBrainliness", 50);
        PlayerPrefs.SetInt("AverageLongNeckness", 50);
        PlayerPrefs.SetInt("AverageHotness", 50);
    }
}
