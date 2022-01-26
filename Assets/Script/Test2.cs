using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Sono un altro awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Sono un altro Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Sono un altro update");
    }

    private void LateUpdate()
    {
        Debug.Log("Sono un altro late update");
    }
}
