using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Sono un awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sono uno Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Sono un update");
    }

    private void LateUpdate()
    {
        Debug.Log("Sono un late update");
    }

    private void FixedUpdate()
    {
        /*
        Debug.Log(Time.time);
        Debug.Log("Sono un fixed update");
        */
    }
}
