using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemy : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private GameObject turret;
    private Quaternion rotation;
    [SerializeField] List<GameObject> targets = new List<GameObject>();
    private void Awake()
    {
        turret = this.gameObject;
        rotation = turret.transform.rotation;
    }

    private void Update()
    {
        if(target!=null)
        {
            turret.transform.LookAt(target.transform.position);
        }
        /*
        if (target != null)
        {
            if (target.activeInHierarchy)
            {
                turret.transform.LookAt(target.transform.position);
            }
            else
                Deactivate();
        }
        */
    }

    private void LateUpdate()
    {
        if((target!=null)&&(!target.activeInHierarchy))
        {
            RemoveTarget(target);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer==8)
        {
            targets.Add(other.gameObject);
            if(target==null)
            {
                SetTarget();
            }
            /*
            target = other.gameObject;
            transform.parent.GetComponent<ShootingTurret>().StartCoroutine(transform.parent.GetComponent<ShootingTurret>().Shoot());
        */    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            RemoveTarget(other.gameObject);
        }
    }

    void SetTarget()
    {
        target = targets[0];
        transform.parent.GetComponent<ShootingTurret>().StartCoroutine(transform.parent.GetComponent<ShootingTurret>().Shoot());
    }

    void RemoveTarget(GameObject obj)
    {
        targets.Remove(obj);
        CheckList();
    }

    void CheckList()
    {
        if(targets.Count==0)
        {
            Deactivate();
        }
        else
        {
            target = targets[0];
        }
    }

    public void Deactivate()
    {
        target = null;
        turret.transform.rotation = rotation;
        transform.parent.GetComponent<ShootingTurret>().StopAllCoroutines();
    }
}
