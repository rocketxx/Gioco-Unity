using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTurret : MonoBehaviour
{
    /*
   public enum TurretType { bullet=1, rocket=5, healing=10}
   public TurretType myTurret;
   */
    public int myTurret;
    [SerializeField] protected int health;
    [SerializeField] protected float cooldown;
    [SerializeField] protected GameObject upgrade;
    [SerializeField] protected int costToUpgrade;
    protected int nextLevel = 2;
    public void SendInformation<T>(T param)
    {
        GuiManager.instance.ShowInformation(param);
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            SendInformation(this);
        }
    }

    public int GetCostToUpgrade()
    {
        return costToUpgrade;
    }

    public int GetHealth()
    {
        return health;
    }

    public float GetCooldDown()
    {
        return cooldown;
    }


    protected virtual void Init()
    {
        health = PlayerTurretManager.instance.GetTurretHealth(tag);
        myTurret = PlayerTurretManager.instance.GetTurretType(tag);
        cooldown = GameData.coolDown;
    }

    public void UpgradeTurret()
    {
        
        GameObject aux = Instantiate(upgrade, transform.position, transform.rotation);
        aux.GetComponent<MainTurret>().SendInformation(aux.GetComponent<MainTurret>());
        PlayerTurretManager.instance.RemoveTurret(this.gameObject);
        PlayerTurretManager.instance.AddTurret(aux);
        Destroy(this.gameObject);
    }
}
