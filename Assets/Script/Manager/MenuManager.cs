using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    [SerializeField] Slider soundSlider, musicSlider;

    private void Awake()
    {
        soundSlider.value = SaveGame.GetSound();
        musicSlider.value = SaveGame.GetMusic();
    }

    public void PlayNewGame(int i)
    {
        SceneManager.LoadScene(i);
        //AsyncOperation op = SceneManager.LoadSceneAsync(i);

    }

    public void PlayNewGame(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SaveSoundVolume()
    {
        SaveGame.SaveSoundVolume(soundSlider.value);
        Debug.Log("Sound volume saved");
    }

    public void SaveMusicVolume()
    {
        SaveGame.SaveMusicVolume(musicSlider.value);
        Debug.Log("Music volume saved");
    }

    public void Exit()
    {
        Application.Quit();
    }

    
}
