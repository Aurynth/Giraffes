using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsCard : MonoBehaviour
{
    public StatsBar Beefiness;
    public StatsBar Speediness;
    public StatsBar Chonk;
    public StatsBar Brainliness;
    public StatsBar LongNeckness;
    public StatsBar Hotness;
    public float TotalScore;
    //public GiraffeParent myGiraffe;

    public void SetStats(GiraffeParent giraffe)
    {
        Beefiness.SetStat(giraffe.Beefiness);
        Speediness.SetStat(giraffe.Speediness);
        Chonk.SetStat(giraffe.Chonk);
        Brainliness.SetStat(giraffe.Brainliness);
        LongNeckness.SetStat(giraffe.LongNeckness);
        Hotness.SetStat(giraffe.Hotness);
        TotalScore = Beefiness.Stat.value + Speediness.Stat.value + Chonk.Stat.value + Brainliness.Stat.value + LongNeckness.Stat.value + Hotness.Stat.value;
        //myGiraffe = giraffe;
    }

}
