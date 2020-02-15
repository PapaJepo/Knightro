using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 move;
    Vector3 rotate;
    Rigidbody rb;
    RaycastHit downward;
    BoxCollider box;
    Vector3 upright;
    Vector3 up;
    Vector3 jump;
    float charge;
   [SerializeField] PhysicMaterial phy;
    bool grounded;
    bool charging;
    bool jittercheck;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        grounded = true;
        charging = true;
    }

    public void OnCollisionStay(Collision collision)
    {
        grounded = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        grounded = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (Physics.Raycast(transform.position, Vector3.down, out downward, 0.7f))
        {
            if (collision.transform.CompareTag("ground") && jittercheck == true)
            {
                up = downward.normal;
                transform.up = up;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                jittercheck = false;
            }

            if (collision.transform.tag != "groud")
            {
                up = downward.normal;
                transform.up = up;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                jittercheck = true;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        move =  transform.forward*Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space)&& charging==true)
        {
            charge += 100 * Time.deltaTime;
            jump = transform.forward * charge;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            charging = true;
        }
        
        //upright = Vector3.Cross(transform.position + Vector3.forward, downward.point);
        if (Input.GetAxisRaw("Vertical") == 0)
        {
            box.material = phy;
        }
        else
        {
            box.material = null;
        }

        rotate = new Vector3(transform.rotation.x,transform.rotation.y+Input.GetAxisRaw("Horizontal")*500,transform.rotation.z);
        
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
        Gizmos.color = Color.yellow;
        
    }

    public void FixedUpdate()
    {
        Vector3 veltrac = rb.velocity;
        if (grounded == true)
        {
            rb.velocity = rb.velocity + move*30*Time.fixedDeltaTime;
            veltrac = rb.velocity;
        }

        if (grounded == false)
        {
            rb.AddForce(move * 500*Time.fixedDeltaTime);
        }
        if (Input.GetKeyUp(KeyCode.Space) && charging == true || charge >=200 && charging == true)
        {
            rb.AddForce(jump*5);
            rb.velocity = veltrac*1.5f;
            charging = false;
            charge = 0;
            
        }
        //rb.MoveRotation(Quaternion.LookRotation( Vector3.Cross(transform.forward,upright)*Time.fixedDeltaTime));
        transform.rotation = Quaternion.Slerp( transform.rotation,Quaternion.Euler( rotate),3*Time.fixedDeltaTime);
        Debug.Log(Input.GetAxis("Horizontal"));
    }
}
