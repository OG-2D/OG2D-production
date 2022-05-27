using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public PlayerScript1 player;
    public Image[] hearts;
    public Sprite isLife, isDead;
    public GameObject PauseScreen;
    public SoundsEffector soundsEffector;
    public AudioSource musicSource, soundSource;

    public void Start()
    {
        musicSource.volume = PlayerPrefs.GetFloat("musicSlider");
        soundSource.volume = PlayerPrefs.GetFloat("soundSlider");

    }

    public void Lose()
    {
        soundsEffector.PlayLoseSound();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
        

    public void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
           hearts[i].sprite = player.GetHearts() > i ? isLife : isDead;
        musicSource.volume = PlayerPrefs.GetFloat("musicSlider");
        soundSource.volume = PlayerPrefs.GetFloat("soundSlider");
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        PauseScreen.SetActive(true);
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        PauseScreen.SetActive(false);
    }

    public void Load(int level)
    {
        Lose();
        PauseOff();
        SceneManager.LoadScene(level);
    }


    public void SaveResults()
    {
        if (!PlayerPrefs.HasKey("Lvl") || PlayerPrefs.GetInt("Lvl") < SceneManager.GetActiveScene().buildIndex)
            PlayerPrefs.SetInt("Lvl", SceneManager.GetActiveScene().buildIndex);
    }
}
