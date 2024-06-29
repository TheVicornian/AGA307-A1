using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphere;  //The object we wish to change

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
           //change the spheres colour to  white
           sphere.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButton("Action"))
            {
               //Increas the spheres scale by 0.01 on all axis
               sphere.transform.localScale += Vector3.one * 0.01f;
               //change colour of the ball again
               sphere.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //set the spheres size back to 1
                sphere.transform.localScale = Vector3.one;
            //Change the spheres colour to yellow
            sphere.GetComponent<Renderer>().material.color = Color.black;
        }
    }
}

