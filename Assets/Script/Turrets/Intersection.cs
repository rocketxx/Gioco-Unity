using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intersection : MonoBehaviour
{
    bool isFine = true;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer==9)
        {
            Debug.Log(Time.time);
            Debug.Log("COLLISIONE");
            isFine = false;
        }
    }

    public bool GetIsFine()
    {
        return isFine;
    }
}
