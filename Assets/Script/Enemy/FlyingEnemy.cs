using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : Enemy
{
    float t = 0;
    [SerializeField] float timeToReach;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    IEnumerator MuoviElicottero()
    {
        t = 0;
        Vector3 actualPosition = transform.position;
        Vector3 targetPosition = target.position;
        while(t<1)
        {
            t += Time.deltaTime / timeToReach;
            transform.position = new Vector3(Mathf.Lerp(actualPosition.x, targetPosition.x, t), transform.position.y, Mathf.Lerp(actualPosition.z, targetPosition.z, t));
            yield return 0;
        }
        PlayerManager.instance.TakeDamage(strength);
        gameObject.SetActive(false);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        target=checkPoints[checkPoints.Length - 1];
        StartCoroutine(MuoviElicottero());
    }
}
