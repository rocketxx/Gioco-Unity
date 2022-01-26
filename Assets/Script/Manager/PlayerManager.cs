using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] float health;
    //public Material mat;
    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        /*
        float offset = Time.time * 0.1f;
        mat.mainTextureOffset = new Vector2(offset, 0);
        */
        
    }

    public void TakeDamage(float damage)
    {
        SoundManager.instance.PlayPlayerAttack();
        health -= damage;
        if(health<=0)
        {
            SoundManager.instance.PlayDefeat();
            CoinManager.instance.SaveCoins();
            Time.timeScale = 0;
        }
    }
}
