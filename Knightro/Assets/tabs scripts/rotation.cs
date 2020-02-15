using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    Vector3 lookrot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lookrot = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookrot,Vector3.up);
        transform.position = Vector3.Lerp(transform.position,  player.transform.position + offset, 3*Time.deltaTime);

    }
}
