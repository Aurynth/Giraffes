using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeParent : MonoBehaviour
{
    public StatsCard FemaleCard;
    public StatsCard MaleCard;
    public GameObject Giraffe;
    public bool male;
    public int Beefiness;
    public int Speediness;
    public int Chonk;
    public int Brainliness;
    public int LongNeckness;
    public int Hotness;

    // Start is called before the first frame update
    void Start()
    {
        int[] offsets = new int[6];

        for (int i = 0; i < offsets.Length; i++)
        {
            offsets[i] = Random.Range(-10, 10);
        }

        Beefiness = PlayerPrefs.GetInt("AverageBeefiness") + offsets[0];
        Speediness = PlayerPrefs.GetInt("AverageSpeediness") + offsets[1];
        Chonk = PlayerPrefs.GetInt("AverageChonk") + offsets[2];
        Brainliness = PlayerPrefs.GetInt("AverageBrainliness") + offsets[3];
        LongNeckness = PlayerPrefs.GetInt("AverageLongNeckness") + offsets[4];
        Hotness = PlayerPrefs.GetInt("AverageHotness") + offsets[5];

        if(PlayerPrefs.GetInt("MalePopulation") > 0)
        {
            male = true;
            int newMalePop = PlayerPrefs.GetInt("MalePopulation") - 1;
            PlayerPrefs.SetInt("MalePopulation", newMalePop);
        }
        else
        {
            male = false;
        }

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform)
                {
                    GiraffeParent gp;
                    if(gp = hit.transform.GetComponent<GiraffeParent>())
                    {
                        PopulateStats(gp);
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    public void PopulateStats(GiraffeParent me)
    {
        if(me.male)
        {
            MaleCard.SetStats(me);
        }
        else
        {
            FemaleCard.SetStats(me);
        }
    }
}
