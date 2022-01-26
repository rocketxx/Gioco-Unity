using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurretManager : MonoBehaviour
{
    [SerializeField] GameObject turret, ghostTurret;
    RaycastHit hit;
    [SerializeField] LayerMask layerMask, layerMaskGhost;
    List<GameObject> instantiatedTurrets = new List<GameObject>();
    public static PlayerTurretManager instance;

    public enum CostToBuy
    {
        MachineGun=30,
        RocketLauncher=20
    }
    
    public enum TurretHealth
    {
        MachineGun=5,
        RocketLauncher=10
    }

    public enum TurretType
    {
        MachineGun = 1,
        RocketLauncher = 5,
        HealingTurret=10
    }

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        Debug.Log(Input.GetAxisRaw("Horizontal"));
        if(Input.GetAxis("Horizontal")>0)
        {
            //Go right
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            //Go left
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            //Go forward
        }
        else
        {
            //Go backward
        }
    }
    */

    private void Update()
    {
        if(ghostTurret!=null)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMaskGhost))
            {
                ghostTurret.transform.position = hit.point;
                if((hit.collider.gameObject.layer!=11)||(CheckIntersections(ghostTurret)))
                {
                    ghostTurret.transform.ChangeTurretColor(Color.red);
                }
                else
                {
                    ghostTurret.transform.ChangeTurretColor(Color.green);
                        if ((Input.GetMouseButtonDown(0))&&(CoinManager.instance.RemoveMoney(GetCostToBuy(ghostTurret.tag))))
                        {
                            GameObject aux = Instantiate(turret, hit.point, hit.transform.rotation);

                            instantiatedTurrets.Add(aux);
                            switch(aux.tag)
                            {
                            case "MachineGun":
                                aux.AddComponent<MachineGun>();
                            break;

                            case "RocketLauncher":
                                aux.AddComponent<RocketLauncher>();
                            break;
                            }
                                                                           
                            aux.transform.GetChild(0).gameObject.AddComponent<TargetEnemy>();
                        
                        }
                    
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Reset();
            }
        }

    /*
            if ((Input.GetMouseButtonDown(0))&&(turret!=null))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity,layerMask))
            {

                GameObject aux = Instantiate(turret, hit.point, hit.transform.rotation);
                if (!CheckIntersections(aux))
                {
                    instantiatedTurrets.Add(aux);
                    aux.AddComponent<MachineGun>();
                    aux.transform.GetChild(0).gameObject.AddComponent<TargetEnemy>();
                }
                else
                    Destroy(aux);
                
            }
        }
        */
    }

    public void SetTurretType(GameObject turretType)
    {
        turret = turretType;
        ghostTurret = Instantiate(turret);
    }

    
    private bool CheckIntersections(GameObject aux)
    {
        if (instantiatedTurrets.Count==0)
        {
            return false;
        }
        else
        {
            foreach(GameObject turret in instantiatedTurrets)
            {
                if(aux.GetComponent<BoxCollider>().bounds.Intersects(turret.GetComponent<BoxCollider>().bounds))
                {
                    return true;
                }
            }
        }
        return false;

        
    }

    public void AddTurret(GameObject turret)
    {
        instantiatedTurrets.Add(turret);
    }

    public void RemoveTurret(GameObject turret)
    {
        instantiatedTurrets.Remove(turret);
    }

    public int GetCostToBuy(string type)
    {
        return (int)System.Enum.Parse(typeof(CostToBuy), type);
    }

    
    public int GetTurretHealth(string  type)
    {
        return (int)System.Enum.Parse(typeof(TurretHealth), type);
    }

    public int GetTurretType(string type)
    {
        return (int)System.Enum.Parse(typeof(TurretType), type);
    }

    private void Reset()
    {
        turret = null;
        Destroy(ghostTurret);
        
    }

}
