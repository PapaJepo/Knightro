using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    [SerializeField] GameObject player;
    Vector3 lookrot;
    [SerializeField] int y;
    [SerializeField] int x;
    Camera cam;
    [SerializeField] bool chargeeffect;
   [SerializeField] float charge;
    public void Start()
    {
        
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && chargeeffect==false)
        {
            charge += 50 * Time.deltaTime;
            
        }

    }

    // Update is called once per frame
    public void FixedUpdate()
     {
         lookrot = player.transform.position - transform.position;
         transform.rotation = Quaternion.LookRotation(lookrot, Vector3.up);
         transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position + ( player.transform.forward * -1 * x) + Vector3.up * y, 6 * Time.fixedDeltaTime);
        if(chargeeffect == true)
        {
            cam.fieldOfView =Mathf.LerpUnclamped(cam.fieldOfView, 65 + charge ,5*Time.fixedDeltaTime);

            if(cam.fieldOfView >60+charge)
            {
                charge = 0;
                chargeeffect = false;
                
            }
        }

        if (chargeeffect == false && cam.fieldOfView != 60)
        {
            cam.fieldOfView = Mathf.LerpUnclamped(cam.fieldOfView, 60, 6 * Time.fixedDeltaTime);
        }

        if(Input.GetKeyUp(KeyCode.Space)|| charge >=100)
        {
            chargeeffect = true;
        }
        

         //transform.RotateAround(player.transform.position,100*Time.deltaTime*Input.GetAxisRaw("Horizontal"));
         //transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime);
     }
}
