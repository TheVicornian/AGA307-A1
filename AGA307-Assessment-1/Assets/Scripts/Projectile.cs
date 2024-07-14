using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Target"))
        {
            //change target colour on collision
            collision.collider.GetComponent<Renderer>().material.color = Color.red;

        }
    


    }   
}
