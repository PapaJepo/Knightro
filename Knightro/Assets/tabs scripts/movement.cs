using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Vector3 move;
    Vector3 rotate;
    public Rigidbody rb;
    RaycastHit downward;
    BoxCollider box;
    Vector3 upright;
    Vector3 up;
    Vector3 jump;
    float charge;
    float newrot;
    [SerializeField] int angulardrag;
    [SerializeField] int rotspeed;
    [SerializeField] PhysicMaterial phy;
    [SerializeField] int maxspeed;
    [SerializeField] int speed;
    [SerializeField] int stoppingspeed;
    [SerializeField] int chargedelay;
    [SerializeField] int pickupspeed, pickupslow;
    [SerializeField] string[] buttons = new string[1];
    
    public float chargeactivate;
    bool grounded;
    bool charging;
    bool jittercheck;
    GameObject test;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        box = GetComponent<BoxCollider>();
        grounded = true;
        charging = true;
        test = null;
        newrot = 0;
        jittercheck = true;
        chargeactivate = 0;
    }

    public void OnCollisionStay(Collision collision)
    {

        if (Physics.Raycast(transform.position + Vector3.down, Vector3.down, out downward, 0.7f))
        {
            if (collision.transform.tag != "ground")
            {
                jittercheck = false;
                rb.constraints = RigidbodyConstraints.None;
                up = downward.normal;
                transform.up = up;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                test = collision.gameObject;
                newrot = 0;

            }
        }
        if (Physics.Raycast(transform.position + Vector3.forward + Vector3.down, Vector3.down, out downward, 0.7f))
        {
            if (collision.transform.tag != "ground")
            {
                jittercheck = false;
                rb.constraints = RigidbodyConstraints.None;
                up = downward.normal;
                transform.up = up;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                test = collision.gameObject;
                newrot = 0;

            }
        }
        grounded = true;
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag != "ground")
        {
            jittercheck = true;
        }
        grounded = false;
    }

    public void OnCollisionEnter(Collision collision)
    {

        if (Physics.Raycast(transform.position + Vector3.down, Vector3.down, out downward, 0.7f))
        {

            if (collision.transform.CompareTag("ground") && jittercheck == true && collision.gameObject != test)
            {
                rb.constraints = RigidbodyConstraints.None;
                up = downward.normal;
                transform.up = up;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
                test = collision.gameObject;
            }

        }

        if (collision.transform.CompareTag("pickupspeed"))
        {
            collision.gameObject.GetComponent<pickupscript>().truth = true;
            charge = pickupspeed;
            charging = true;
        }

        if (collision.transform.CompareTag("pickupslow"))
        {
            collision.gameObject.GetComponent<pickupscript>().truth = true;
            rb.velocity -= transform.forward*pickupslow;
        }
    }

    // Update is called once per frame
    void Update()
    {
        chargeactivate += Time.deltaTime;

        move = transform.forward * Input.GetAxisRaw(buttons[0]);

        if (Input.GetAxisRaw(buttons[0]) < 0)
        {
            phy.dynamicFriction = stoppingspeed;
            phy.staticFriction = stoppingspeed - 2;
        }
        else
        {
            phy.dynamicFriction = 2;
            phy.staticFriction = 1;
        }

        if (Input.GetButton(buttons[2]) && charging == true && chargeactivate >= chargedelay)
        {
            charge += 100 * Time.deltaTime;
            jump = transform.forward * charge;
        }

        if (Input.GetButtonUp(buttons[2]))
        {
            charging = true;
        }

        //upright = Vector3.Cross(transform.position + Vector3.forward, downward.point);

        newrot += Input.GetAxisRaw(buttons[1]) * Time.deltaTime;
        rotate = new Vector3(transform.rotation.x, newrot, transform.rotation.z);
        Debug.DrawRay(transform.position + Vector3.forward + Vector3.down, Vector3.down, Color.red);

    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down);
        Gizmos.color = Color.yellow;

    }

    public void FixedUpdate()
    {
        Vector3 veltrac = rb.velocity;
        if (grounded == true && rb.velocity.magnitude < 50)
        {
            rb.velocity = rb.velocity + move * speed * Time.fixedDeltaTime;

        }

        if (grounded == false)
        {
            rb.AddForce(move * 500 * Time.fixedDeltaTime);
        }

        else if (rb.velocity.magnitude == 0)
        {
            rb.AddForce(move * 300);
        }
        if (Input.GetButtonUp(buttons[2]) && charging == true || charge >= 200 && charging == true)
        {
            chargeactivate = 0;
            rb.AddForce(jump * 5);
            rb.velocity = veltrac * 1.5f;
            charging = false;
            charge = 0;

        }
        //rb.MoveRotation(Quaternion.LookRotation( Vector3.Cross(transform.forward,upright)*Time.fixedDeltaTime));
        if (jittercheck == true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotate * rotspeed), 3 * Time.fixedDeltaTime);

        }
        if (Input.GetAxisRaw(buttons[1]) != 0)
        {
            rb.velocity -= transform.forward * Input.GetAxisRaw(buttons[1]) * angulardrag * Time.fixedDeltaTime;
        }

    }
}