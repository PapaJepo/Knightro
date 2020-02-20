using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fillcharge : MonoBehaviour
{
    public movement player;
    public Image Charge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.charge<200)
        {
            Charge.fillAmount = player.charge / 100;
        }
        else
        {
            Charge.fillAmount = 0;
        }
    }
}
