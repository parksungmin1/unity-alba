using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicsource;
    public AudioSource btnsource;
 
    void Start()
    {
        DontDestroyOnLoad(musicsource);
    }
    public void SetMusicVolume(float volume)
    {
        musicsource.volume = volume;
    }

    public void SetButtonVolume(float volume)
    {
        btnsource.volume = volume;
    }

    public void OnSfx()
    {
        btnsource.Play();
    }

    public void OnBtnClick()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void NoSound()
    {
        musicsource.Pause();
    }

   
}
