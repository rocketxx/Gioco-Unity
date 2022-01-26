using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : ShootingTurret
{
    protected override void Start()
    {
        Init();
        base.Start();
    }

    protected override void Init()
    {
        base.Init();
        ammo = (GameObject)Resources.Load("Rocket_Projectile");
        upgrade = (GameObject)Resources.Load("RocketTower" + nextLevel);
        costToUpgrade = 20;
    }
}
