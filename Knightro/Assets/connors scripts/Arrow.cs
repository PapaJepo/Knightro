using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private int CurrentWaypoint;
    //public GameObject CurrentObject;
    public List<Transform> Waypoints;
    // Start is called before the first frame update
    void Start()
    {
        CurrentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWaypoints();
        //Vector3 m = CurrentObject.transform.position;
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.RotateTowards(m), 1f);
        transform.LookAt(Waypoints[CurrentWaypoint]);
    }

    void UpdateWaypoints()
    {
        if(Vector3.Distance(Waypoints[CurrentWaypoint].position,this.transform.position) < 10)
        {
            CurrentWaypoint = (CurrentWaypoint + 1)%Waypoints.Count;
        }
    }
}
