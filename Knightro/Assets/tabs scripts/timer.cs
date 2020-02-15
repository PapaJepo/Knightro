using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    Text text;
    float starttime;
    // Start is called before the first frame update
    void Start()
    {
        starttime = Time.time;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - starttime;
        string min = ((int)t / 60).ToString();
        string sec = (t % 60).ToString("f3");
        text.text = min + ":" + sec;
    }
}
