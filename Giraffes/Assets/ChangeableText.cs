using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeableText : MonoBehaviour
{
    public TextMeshProUGUI txt;
    private string key;
    private int value;

    void Start()
    {
        value = PlayerPrefs.GetInt(txt.text);
        key = txt.text;
        txt.text = key + ": " + value;
    }

    // Update is called once per frame
    void Update()
    {
        if(value != PlayerPrefs.GetInt(key))
        {
            value = PlayerPrefs.GetInt(key);
            txt.text = key + ": " + value;
        }
        
    }
}
