using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinManager : MonoBehaviour
{
    [SerializeField] Text coinText;
    public static CoinManager instance;
    [SerializeField] int coins;
    private void Awake()
    {
        
        instance = this;
    }

    private void Start()
    {
        coins = SaveGame.GetCoins();
        RenderCoins();
    }

    public void AddCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        RenderCoins();
    }

    private void RenderCoins()
    {
        coinText.text = coins.ToString();
    }

    public void SaveCoins()
    {
        SaveGame.SaveCoins(coins);
    }

    public bool RemoveMoney(int moneyToRemove)
    {
        if(moneyToRemove>coins)
        {
            return false;
        }
        coins -= moneyToRemove;
        coinText.text = coins.ToString();
        return true;
    }
}
