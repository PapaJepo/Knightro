using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Place : MonoBehaviour
{
    public GameObject Player1;
    public GameObject Player2;
    public TMP_Text PlaceText1;
    public TMP_Text PlaceText2;

    public Arrow P1;
    public Arrow P2;


    public GameObject Place11st;
    public GameObject Place12nd;


    public GameObject Place21st;
    public GameObject Place22nd;
    // Start is called before the first frame update

    /*private void Awake()
    {
        P1 = Player1.GetComponent<Arrow>();
        P2 = Player2.GetComponent<Arrow>();
    }*/

    void Start()
    {
        P1 = Player1.GetComponent<Arrow>();
        P2 = Player2.GetComponent<Arrow>();
    }
    
    //Player1.GetComponent<Arrow>().

    // Update is called once per frame
    void FixedUpdate()
    {
    

        if(P1.LapCounter == P2.LapCounter)
        {
            if(P1.CurrentWaypoint == P2.CurrentWaypoint)
            {
                if(Vector3.Distance(P1.Waypoints[P1.CurrentWaypoint].position,Player1.transform.position) < Vector3.Distance(P2.Waypoints[P2.CurrentWaypoint].position, Player2.transform.position))
                {
                    PlaceText1.text = "" + 1;
                    PlaceText2.text = "" + 2;

                    Place11st.SetActive(true);
                    Place22nd.SetActive(true);
                    Place12nd.SetActive(false);
                    Place21st.SetActive(false);

                }
                else if(Vector3.Distance(P1.Waypoints[P1.CurrentWaypoint].position, Player1.transform.position) > Vector3.Distance(P2.Waypoints[P2.CurrentWaypoint].position, Player2.transform.position))
                {
                    PlaceText1.text = "" + 2;
                    PlaceText2.text = "" + 1;

                    Place11st.SetActive(false);
                    Place22nd.SetActive(false);
                    Place12nd.SetActive(true);
                    Place21st.SetActive(true);
                }
            }
            else if(P1.CurrentWaypoint > P2.CurrentWaypoint)
            {
                PlaceText1.text = "" + 1;
                PlaceText2.text = "" + 2;

                Place11st.SetActive(true);
                Place22nd.SetActive(true);
                Place12nd.SetActive(false);
                Place21st.SetActive(false);
            }
            else if(P1.CurrentWaypoint < P2.CurrentWaypoint)
            {
                PlaceText1.text = "" + 2;
                PlaceText2.text = "" + 1;

                Place11st.SetActive(false);
                Place22nd.SetActive(false);
                Place12nd.SetActive(true);
                Place21st.SetActive(true);
            }
        }
        else if(P1.LapCounter > P2.LapCounter)
        {
            PlaceText1.text = "" + 1;
            PlaceText2.text = "" + 2;

            Place11st.SetActive(true);
            Place22nd.SetActive(true);
            Place12nd.SetActive(false);
            Place21st.SetActive(false);
        }
        else if(P1.LapCounter < P2.LapCounter)
        {
            PlaceText1.text = "" + 2;
            PlaceText2.text = "" + 1;

            Place11st.SetActive(false);
            Place22nd.SetActive(false);
            Place12nd.SetActive(true);
            Place21st.SetActive(true);
        }
    }
}
