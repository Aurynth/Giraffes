using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyGiraffe : MonoBehaviour
{
    public GameObject Baby;
    public bool male;
    public int Beefiness;
    public int Speediness;
    public int Chonk;
    public int Brainliness;
    public int LongNeckness;
    public int Hotness;

    public void newBaby(GiraffeParent Mom, GiraffeParent Dad)
    {
        Beefiness = GetMixOfParents(Mom.Beefiness, Dad.Beefiness);
        Speediness = GetMixOfParents(Mom.Speediness, Dad.Speediness);
        Chonk = GetMixOfParents(Mom.Chonk, Dad.Chonk);
        Brainliness = GetMixOfParents(Mom.Brainliness, Dad.Brainliness);
        LongNeckness = GetMixOfParents(Mom.LongNeckness, Dad.LongNeckness);
        Hotness = GetMixOfParents(Mom.Hotness, Dad.Hotness);
    }

    private int GetMixOfParents(int Mom, int Dad)
    {
        float scale = Random.Range(0, 1);
        int maxVal = Mathf.Max(Mom, Dad);
        int minVal = Mathf.Min(Mom, Dad);
        int diff = maxVal - minVal;
        return (int)(minVal + (diff * scale));
    }
}
