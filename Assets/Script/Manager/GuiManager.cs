using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GuiManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Text turretName, strength, health, cooldown;
    MainTurret myTurret;
    public static GuiManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void ShowInformation<T>(T turret)
    {
        if(myTurret!=null)
        ChangeTurretColor();
        panel.SetActive(true);
        string type = turret.GetType().ToString();
        myTurret = turret as MainTurret;
        /*
        switch(type)
        {
            case "MachineGun":
                MachineGun gun = turret as MachineGun;
                //myTurret = gun.GetComponent<MainTurret>();
                
            break;

            case "RocketLauncher":
                RocketLauncher launcher = turret as RocketLauncher;
                
            break;
        }
        */
        turretName.text = myTurret.gameObject.name;
        strength.text = ((int)myTurret.myTurret).ToString();
        health.text = myTurret.GetHealth().ToString();
        cooldown.text = myTurret.GetCooldDown().ToString();
        ChangeTurretColor(Color.green);
    }

    public void ChangeTurretColor()
    {
        ChangeTurretColor(Color.white);
    }

    public void ChangeTurretColor(Color color)
    {
        myTurret.transform.ChangeTurretColor(color);
    }

    public void UpgradeTurret()
    {
        if(CoinManager.instance.RemoveMoney(myTurret.GetCostToUpgrade()))
        {
            myTurret.UpgradeTurret();
        }
    }
}
