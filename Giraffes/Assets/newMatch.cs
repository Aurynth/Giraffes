using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class newMatch : MonoBehaviour
{
    public StatsCard Male;
    public StatsCard Female;
    public GameObject WinLevelMessage;
    public GameObject MissingParentMessage;
    public GameObject IncompatibleMessage;
    public GameObject FailMessage;
    public TextMeshProUGUI FailText;
    public EndGame EndGameScreen;
    
    public void Match()
    {
        if (Male.myGiraffe != null && Female.myGiraffe != null)
        {
            if (GetCompatibility() > 95)
            {
                BabyGiraffe Baby = new BabyGiraffe();
                Baby.newBaby(Female.myGiraffe, Male.myGiraffe);
                NextLevel(Baby);

                if (PlayerPrefs.GetInt("AverageBeefiness") > 95)
                {
                    FailText.text = "Your Giraffe grew too beefy!\n It has stomped on all the others, and there are no giraffes left!\nGame Over! :(";
                    FailMessage.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Lose");
                }
                else if (PlayerPrefs.GetInt("AverageBeefiness") < 10)
                {
                    FailText.text = "Your Giraffe is so small, when it met a lion, it was swallowed whole!\n Game Over! :O";
                    FailMessage.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Lose");
                }
                else if (PlayerPrefs.GetInt("AverageHotness") > 95)
                {
                    FailText.text = "Your Giraffe is so hot it got smothered to death by all it's suitors!\n Game Over! X(";
                    FailMessage.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Lose");
                }
                else if (PlayerPrefs.GetInt("AverageIntelligence") > 95)
                {
                    FailText.text = "Your Giraffe's grew too brainly!\n They decide they are better off on their own and they leave Earth to its DOOM!\n Game Over! 8-X";
                    FailMessage.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("Lose");
                }
                else
                {
                    if (PlayerPrefs.GetInt("Generation") < 10)
                    {
                        WinLevelMessage.SetActive(true);
                    }
                    else
                    {
                        EndGame();
                    }
                }
            }
            else
            {
                IncompatibleMessage.SetActive(true);
                FindObjectOfType<AudioManager>().Play("IncompatibleGiraffes");
            }
        }
        else
        {
            MissingParentMessage.SetActive(true);
            FindObjectOfType<AudioManager>().Play("IncompatibleGiraffes");
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
        int[] offsets = new int[6];

        for (int i = 0; i < offsets.Length; i++)
        {
            offsets[i] = Random.Range(-10, 10);
        }

        PlayerPrefs.SetInt("MalePopulation", 5);
        PlayerPrefs.SetInt("AverageBeefiness", Baby.Beefiness + offsets[0]);
        PlayerPrefs.SetInt("AverageSpeediness", Baby.Speediness + offsets[1]);
        PlayerPrefs.SetInt("AverageChonk", Baby.Chonk + offsets[2]);
        PlayerPrefs.SetInt("AverageBrainliness", Baby.Brainliness + offsets[3]);
        PlayerPrefs.SetInt("AverageLongNeckness", Baby.LongNeckness + offsets[4]);
        PlayerPrefs.SetInt("AverageHotness", Baby.Hotness + offsets[5]);
    }

    void EndGame()
    {
        EndGameScreen.Canvas.SetActive(true);
        if(PlayerPrefs.GetInt("AverageBrainliness") >= 85)
        {
            EndGameScreen.BrainlyWin.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Win");
        }
        else if(PlayerPrefs.GetInt("AverageBeefiness") >= 85)
        {
            EndGameScreen.BeefyWin.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Win");
        }
        else if (PlayerPrefs.GetInt("AverageHotness") >= 85)
        {
            EndGameScreen.HotWin.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Win");
        }
        else if (PlayerPrefs.GetInt("AverageLongNeckness") >= 85)
        {
            EndGameScreen.LongNeckWin.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Win");
        }
        else 
        {
            EndGameScreen.Lose.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Lose");
        }
    }
}
