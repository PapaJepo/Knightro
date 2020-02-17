using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject CurrentObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = CurrentObject.transform.position;
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.RotateTowards(m), 1f);
        transform.LookAt(CurrentObject.transform);
    }
}
