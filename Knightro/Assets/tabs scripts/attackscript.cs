using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackscript : MonoBehaviour
{
   
    [SerializeField] string axis;
    Vector3 offset;
    [SerializeField] movement opplayer;
    [SerializeField] bool player1, player2;
    BoxCollider box;
    [SerializeField] int boxdecider;

    public void Start()
    {
        box = GetComponent<BoxCollider>();
    }

    // Start is called before the first frame update
    public void OnTriggerEnter(Collider other)
    {
        if (player1 == true)
        {
            if (other.gameObject.CompareTag("player1"))
            {
                opplayer.rb.AddForce(other.gameObject.transform.forward + other.gameObject.transform.right * 1000);
            }
        }
        if (player2 == true)
        {
            if (other.gameObject.CompareTag("player2"))
            {
                opplayer.rb.AddForce(other.gameObject.transform.forward + other.gameObject.transform.right * 1000);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw(axis)== boxdecider)
        {
            box.enabled = true;
        }
        else
        {
            box.enabled = false;
        }
        Debug.Log(Input.GetAxisRaw(axis));
    }

   
}
