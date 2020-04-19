using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MatchButton : MonoBehaviour
{
    public newMatch myMatch;
    private GiraffeParent Female;
    private GiraffeParent Male;
    public TextMeshProUGUI myText;

    // Start is called before the first frame update
    void Start()
    {
        Female = null;
        Male = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Female != myMatch.Female.myGiraffe || Male != myMatch.Male.myGiraffe)
        {
            if (myMatch.Female.myGiraffe && myMatch.Male.myGiraffe)
            {
                myText.text = (int)myMatch.GetCompatibility() + "% Match";
                Female = myMatch.Female.myGiraffe;
                Male = myMatch.Male.myGiraffe;
            }
            else
            {
                myText.text = "Match";
                Female = myMatch.Female.myGiraffe;
                Male = myMatch.Male.myGiraffe;
            }
        }
    }
}
