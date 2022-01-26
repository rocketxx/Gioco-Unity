using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : ShootingTurret
{
    protected override void Start()
    {
        Init();
        base.Start();
    }

    protected override void Init()
    {
        base.Init();
        ammo = (GameObject)Resources.Load("Bullet");
        //upgrade = (GameObject)Resources.Load("RocketTower" + nextLevel);
    }
}
