using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [SerializeField] Text waveText;
    int wave = 1;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if(_instance==null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                if(_instance==null)
                {
                    Debug.LogError("No Game manager in scene");
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance==null)
        {
            _instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        Screen.fullScreen = true;
        foreach(Resolution res in Screen.resolutions)
        {
            Debug.Log(res);
        }
        Screen.SetResolution(800, 600, false);
        waveText.text = wave.ToString();
    }
}
