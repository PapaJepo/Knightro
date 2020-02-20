using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupscript : MonoBehaviour
{
   public bool truth;
    MeshRenderer mesh;
    Collider col;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        truth = false;
        mesh = GetComponent<MeshRenderer>();
        col = GetComponent<Collider>();
       
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if(truth == true)
        {
            col.enabled = false;
            mesh.enabled = false;
           
            timer += Time.deltaTime;
        }
        else if(truth == false)
        {
            mesh.enabled = true;
            col.enabled = true;
          
        }

        if(timer >= 5)
        {
            truth = false;
            timer = 0;
        }
    }
}
