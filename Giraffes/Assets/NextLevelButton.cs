using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelButton : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        int date = PlayerPrefs.GetInt("Date") + 10;
        int generation = PlayerPrefs.GetInt("Generation") + 1;
        PlayerPrefs.SetInt("Date", date);
        PlayerPrefs.SetInt("Generation", generation);
    }
}
