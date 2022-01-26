using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBullet : MonoBehaviour
{

    private void Start()
    {
        
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            //do something
            yield return 0;
            
        }
        
    }

    IEnumerator Shoot2()
    {

        yield return new WaitForSeconds(5);
        Debug.Log("Fine Shoot 2");
    }
}
