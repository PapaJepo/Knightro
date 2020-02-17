using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;
    Vector3 lookrot;
    Vector3 newrot;
    [SerializeField] float distance;
    float rot;

    // Update is called once per frame
    public void FixedUpdate()
     {
         lookrot = player.transform.position - transform.position;
         transform.rotation = Quaternion.LookRotation(lookrot, Vector3.up);
         transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position + ( player.transform.forward * -1 * 7) + Vector3.up * 3, 6 * Time.fixedDeltaTime);

         //transform.RotateAround(player.transform.position,100*Time.deltaTime*Input.GetAxisRaw("Horizontal"));
         //transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime);
     }
}
