using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Arrow : MonoBehaviour
{
    public TMP_Text LapText;

    private int CurrentWaypoint;
    //public GameObject CurrentObject;
    public List<Transform> Waypoints;

    public int LapCounter;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UI();
        Debug.Log(Vector3.Distance(Waypoints[CurrentWaypoint].position, this.transform.position));
        UpdateWaypoints();
        //Vector3 m = CurrentObject.transform.position;
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.RotateTowards(m), 1f);
        transform.LookAt(Waypoints[CurrentWaypoint]);


    }

    void UpdateWaypoints()
    {
        if(Vector3.Distance(Waypoints[CurrentWaypoint].position,this.transform.position) < 30)
        {
            CurrentWaypoint = (CurrentWaypoint + 1)%Waypoints.Count;
            if (CurrentWaypoint + 1 == Waypoints.Count)
            {
                LapCounter++;
            }
        }
    }

    void UI()
    {
        LapText.text = "" + LapCounter + "/3";
    }
}
