using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newMatch : MonoBehaviour
{
    public StatsCard Male;
    public StatsCard Female;
    
    public void Match()
    {
        if (Male.myGiraffe != null && Female.myGiraffe != null)
        {
            if (GetCompatibility() > 95)
            {
                BabyGiraffe Baby = new BabyGiraffe();
                Baby.newBaby(Female.myGiraffe, Male.myGiraffe);
                if (PlayerPrefs.GetInt("Generation") <= 10)
                {
                    print("You found a match - Next Generation!");
                    NextLevel(Baby);
                    //respawn giraffes
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                else
                {
                    //Win or Lose Condition tested
                }
            }
            else
            {
                print("No Match!");
            }
        }
        else
        {
            print("You must select a male and female giraffe");
        }
    }

    public float GetCompatibility()
    {
        float maxScore = Mathf.Max(Male.TotalScore, Female.TotalScore);
        float minScore = Mathf.Min(Male.TotalScore, Female.TotalScore);
        float percentage = minScore / maxScore;

        return (percentage * 100);
    }

    public void NextLevel(BabyGiraffe Baby)
    {
        int date = PlayerPrefs.GetInt("Date") + 10;
        int generation = PlayerPrefs.GetInt("Generation") + 1;

        int[] offsets = new int[6];

        for (int i = 0; i < offsets.Length; i++)
        {
            offsets[i] = Random.Range(-10, 10);
        }

        PlayerPrefs.SetInt("Date", date);
        PlayerPrefs.SetInt("Generation", generation);
        PlayerPrefs.SetInt("MalePopulation", 5);
        PlayerPrefs.SetInt("AverageBeefiness", Baby.Beefiness + offsets[0]);
        PlayerPrefs.SetInt("AverageSpeediness", Baby.Speediness + offsets[1]);
        PlayerPrefs.SetInt("AverageChonk", Baby.Chonk + offsets[2]);
        PlayerPrefs.SetInt("AverageBrainliness", Baby.Brainliness + offsets[3]);
        PlayerPrefs.SetInt("AverageLongNeckness", Baby.LongNeckness + offsets[4]);
        PlayerPrefs.SetInt("AverageHotness", Baby.Hotness + offsets[5]);
    }
}
