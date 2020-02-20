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
    [SerializeField] int chargemax;
    [SerializeField] string[] buttons = new string[1];
    [SerializeField] int chargedelay;
    [SerializeField] float chargeactivate;
    movement mov;
    bool chargeeffect;
    float charge;
    public void Start()
    {
        mov = player.GetComponent<movement>();
        cam = GetComponent<Camera>();
    }

    public void Update()
    {
        chargeactivate = mov.chargeactivate;
        if (Input.GetButton(buttons[0]) && chargeeffect == false && chargeactivate >= chargedelay)
        {
            charge += chargemax * Time.deltaTime;
            Debug.Log("yes");

        }
        if (Input.GetButtonUp(buttons[0]) || charge >= chargemax * 2)
        {
            chargeactivate = 0;
            chargeeffect = true;

        }

    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        lookrot = player.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookrot, Vector3.up);
        transform.position = Vector3.LerpUnclamped(transform.position, player.transform.position + (player.transform.forward * -1 * x) + Vector3.up * y, 6 * Time.fixedDeltaTime);
        if (chargeeffect == true)
        {
            cam.fieldOfView = Mathf.LerpUnclamped(cam.fieldOfView, 65 + charge, 5 * Time.fixedDeltaTime);

            if (cam.fieldOfView > 60 + charge)
            {
                charge = 0;
                chargeeffect = false;

            }
        }

        if (chargeeffect == false && cam.fieldOfView != 60)
        {
            cam.fieldOfView = Mathf.LerpUnclamped(cam.fieldOfView, 60, 6 * Time.fixedDeltaTime);
        }




        //transform.RotateAround(player.transform.position,100*Time.deltaTime*Input.GetAxisRaw("Horizontal"));
        //transform.RotateAround(player.transform.position, Vector3.up, Input.GetAxisRaw("Horizontal") * 100 * Time.deltaTime);
    }
}