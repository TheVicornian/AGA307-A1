using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringPoint : MonoBehaviour
{
    public int rayDistance = 10;
    Ray ray = new Ray();
    RaycastHit rayHit;

    private void FixedUpdate()
    {
        CastRay();
    }

    void CastRay()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if(Physics.Raycast(ray, out rayHit, rayDistance))
        {
            Debug.Log($"{rayHit.collider.name} was hit");
            if (rayHit.collider.tag == "Target")
                rayHit.collider.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }


}
