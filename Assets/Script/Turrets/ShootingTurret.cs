using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTurret : MainTurret
{
    [SerializeField] protected GameObject[] bulletList;
    [SerializeField] protected int bulletLength;
    [SerializeField] protected Transform spawnPoint;
    [SerializeField] protected GameObject ammo;
    

    [SerializeField] protected int bulletCounter = 0;
    protected bool bulletFound = false;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
        
        bulletLength = GameData.bulletLength;
        spawnPoint = transform.GetChild(0).GetChild(0);
        bulletList = new GameObject[bulletLength];
        for (int i = 0; i < bulletLength; i++)
        {
            bulletList[i] = Instantiate(ammo);
            bulletList[i].GetComponent<HitBullet>().SetBulletType((int)myTurret);
            bulletList[i].SetActive(false);
        }
    }

    public IEnumerator Shoot()
    {
        /*
        yield return 0;
        SpawnBullet();
        */
        while (true)
        {
            SpawnBullet();
            SoundManager.instance.PlayTurretClip(tag);
            yield return new WaitForSeconds(cooldown);

        }
    }

    void SpawnBullet()
    {
        bulletFound = false;
        while (!bulletFound)
        {
            for (int i = bulletCounter; i < bulletLength; i++)
            {
                if (!bulletList[i].activeInHierarchy)
                {
                    bulletList[i].GetComponent<Bullet>().Spawn(spawnPoint);
                    bulletCounter = i + 1;
                    if (bulletCounter == bulletLength - 1)
                        bulletCounter = 0;
                    bulletFound = true;
                    break;
                }

            }
            
        }
    }
}

