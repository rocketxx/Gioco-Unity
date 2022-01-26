using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass : MonoBehaviour
{
    /*
    private void OnCollisionEnter(Collision collision)
    {
        
        foreach(ContactPoint contact in collision.contacts)
        {
            Debug.Log("Collision");
            Debug.DrawRay(contact.point, contact.normal, Color.white, 2000);
        }
    }
    */
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==8)
        {
            Debug.Log(other.tag);
        }
    }
}
