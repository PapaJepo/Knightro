using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class timer : MonoBehaviour
{
    public TMP_Text text;
    float starttime;
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
       
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - starttime;
        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f2");
        text.text = min + ":" + sec;
    }
}
