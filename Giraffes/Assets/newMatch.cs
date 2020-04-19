using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class newMatch : MonoBehaviour
{
    public StatsCard Male;
    public StatsCard Female;

    public void Match()
    {
        if(GetCompatibility() > 75)
        {
            BabyGiraffe Baby = new BabyGiraffe();
            //Baby.newBaby(Female.myGiraffe, Male.MyGiraffe);
        }
        else
        {
            print("No Match!");
        }
    }

    public float GetCompatibility()
    {
        float maxScore = Mathf.Max(Male.TotalScore, Female.TotalScore);
        float minScore = Mathf.Min(Male.TotalScore, Female.TotalScore);
        float percentage = minScore / maxScore;

        return (percentage * 100);
    }
}
