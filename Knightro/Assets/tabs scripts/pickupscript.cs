using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupscript : MonoBehaviour
{
   public bool truth;
    MeshRenderer mesh;
    Collider col;
    Rigidbody rb;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        truth = false;
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(truth == true)
        {
            mesh.enabled = false;
            col.enabled = false;
            rb.isKinematic = true;
            timer += Time.deltaTime;
        }
        else if(truth == false)
        {
            mesh.enabled = true;
            col.enabled = true;
            rb.isKinematic = false;
        }

        if(timer >= 5)
        {
            truth = false;
            timer = 0;
        }
    }
}
